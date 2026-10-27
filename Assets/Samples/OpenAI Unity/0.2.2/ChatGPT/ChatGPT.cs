using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace OpenAI
{
    public class ChatGPT : MonoBehaviour
    {
        [SerializeField] private InputField inputField;
        [SerializeField] private Button button;
        [SerializeField] private ScrollRect scroll;
        [SerializeField] private RectTransform sent;
        [SerializeField] private RectTransform received;
        [SerializeField] private string backendUrl = "";
        [SerializeField] private bool offlineDemoMode = false;
        public CheckBehaviour checkBehaviour;
        private float height;
        private string contextId = "defaultPrompt";
        private string conversationId;
        private string sessionToken;
        private bool sending;
        private UnityWebRequest activeRequest;

        [Serializable] private class ChatRequest
        {
            public string contextId, message, conversationId, requestId;
        }
        [Serializable] private class ChatResponse
        {
            public string reply, conversationId, requestId;
        }

        // Call only with an application session issued by the authenticated backend.
        // Keep sessions in memory. Never pass an OpenAI key or PlayerPrefs user ID.
        public void SetSessionToken(string token)
        {
            if (activeRequest != null) activeRequest.Abort();
            sessionToken = token;
            conversationId = null;
        }

        private void Start()
        {
            button.onClick.AddListener(SendReply);
            ChangePrompt();
            if (offlineDemoMode) AppendMessage("DEMO LUAR TALIAN - jawapan contoh", false);
        }

        public void SetOfflineDemoMode(bool enabled)
        {
            offlineDemoMode = enabled;
            if (enabled) AppendMessage("DEMO LUAR TALIAN - jawapan contoh", false);
        }

        public static string DemoAnswer(string question)
        {
            string q = (question ?? "").Trim().ToLowerInvariant();
            if (q.Contains("amilase") || q.Contains("kanji"))
                return "Amilase membantu menguraikan kanji kepada maltosa, sejenis gula penurun.";
            if (q.Contains("vitamin") || q.Contains("dcpip"))
                return "Vitamin C menurunkan DCPIP, menyebabkan warna birunya luntur. Jus yang lebih kaya vitamin C memerlukan isipadu yang lebih kecil untuk melunturkan DCPIP.";
            if (q.Contains("pinggan") || q.Contains("suku"))
                return "Isi suku pinggan dengan bijirin, suku dengan sumber protein, dan separuh dengan sayur-sayuran serta buah-buahan.";
            return "Ini ialah demo luar talian. Cuba tanya tentang amilase, vitamin C atau Pinggan Sihat Malaysia.";
        }

        private IEnumerator DemoReply(string message)
        {
            sending = true;
            button.interactable = false;
            inputField.interactable = false;
            string lesson = contextId;
            try
            {
                AppendMessage(message, true);
                inputField.text = "Sedang menaip...";
                yield return new WaitForSecondsRealtime(0.8f);
                if (lesson == contextId) AppendMessage(DemoAnswer(message), false);
            }
            finally
            {
                sending = false;
                if (inputField != null) { inputField.text = ""; inputField.interactable = true; }
                if (button != null) button.interactable = true;
            }
        }

        public void ChangePrompt()
        {
            string next = checkBehaviour != null ? checkBehaviour.BehaviourName : null;
            if (string.IsNullOrWhiteSpace(next)) next = "defaultPrompt";
            if (next != contextId) conversationId = null;
            contextId = next;
        }

        private void AppendMessage(string content, bool fromUser)
        {
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 0);
            var item = Instantiate(fromUser ? sent : received, scroll.content);
            var text = item.GetChild(0).GetChild(0).GetComponent<Text>();
            text.supportRichText = false;
            text.text = content;
            item.anchoredPosition = new Vector2(0, -height);
            LayoutRebuilder.ForceRebuildLayoutImmediate(item);
            height += item.sizeDelta.y;
            scroll.content.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            scroll.verticalNormalizedPosition = 0;
        }

        private void SendReply()
        {
            if (sending || string.IsNullOrWhiteSpace(inputField.text)) return;
            if (inputField.text.Length > 2000) return;
            if (offlineDemoMode)
            {
                StartCoroutine(DemoReply(inputField.text.Trim()));
                return;
            }
            if (!Uri.TryCreate(backendUrl, UriKind.Absolute, out var uri) ||
                uri.Scheme != Uri.UriSchemeHttps || !string.IsNullOrEmpty(uri.UserInfo))
            {
                AppendMessage("Perkhidmatan chatbot belum dikonfigurasi. Sila hubungi guru anda.", false);
                return;
            }
            if (string.IsNullOrWhiteSpace(sessionToken))
            {
                AppendMessage("Sila log masuk melalui perkhidmatan yang sah untuk menggunakan chatbot.", false);
                return;
            }
            string message = inputField.text.Trim();
            if (message.Length > 2000)
            {
                AppendMessage("Sila hadkan soalan kepada 2000 aksara.", false);
                return;
            }
            StartCoroutine(RequestReply(message));
        }

        private IEnumerator RequestReply(string message)
        {
            sending = true;
            button.interactable = false;
            inputField.interactable = false;
            string requestedContext = contextId;
            string requestedSession = sessionToken;
            try
            {
                AppendMessage(message, true);
                inputField.text = "";
                var body = new ChatRequest {
                    contextId = requestedContext, message = message,
                    conversationId = conversationId, requestId = Guid.NewGuid().ToString()
                };
                using (var request = new UnityWebRequest(backendUrl, "POST"))
                {
                    activeRequest = request;
                    request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(JsonUtility.ToJson(body)));
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Content-Type", "application/json");
                    request.SetRequestHeader("Authorization", "Bearer " + requestedSession);
                    request.timeout = 40;
                    yield return request.SendWebRequest();
                    if (requestedSession != sessionToken || requestedContext != contextId) yield break;
                    if (request.result != UnityWebRequest.Result.Success)
                    {
                        if (request.responseCode == 401 || request.responseCode == 403)
                        {
                            sessionToken = null;
                            conversationId = null;
                            AppendMessage("Sesi anda telah tamat. Sila log masuk semula.", false);
                        }
                        else if (request.responseCode == 429)
                            AppendMessage("Had penggunaan dicapai. Sila cuba lagi kemudian.", false);
                        else
                            AppendMessage("Chatbot tidak dapat dihubungi. Semak sambungan dan cuba lagi.", false);
                        yield break;
                    }
                    ChatResponse response = null;
                    try { response = JsonUtility.FromJson<ChatResponse>(request.downloadHandler.text); }
                    catch (ArgumentException) { }
                    if (response == null || string.IsNullOrWhiteSpace(response.reply))
                        AppendMessage("Jawapan tidak dapat diproses. Sila cuba lagi.", false);
                    else
                    {
                        conversationId = response.conversationId;
                        AppendMessage(response.reply, false);
                    }
                }
            }
            finally
            {
                activeRequest = null;
                sending = false;
                if (button != null) button.interactable = true;
                if (inputField != null) inputField.interactable = true;
            }
        }

        private void OnDisable()
        {
            if (activeRequest != null) activeRequest.Abort();
            StopAllCoroutines();
            activeRequest = null;
            sending = false;
            if (offlineDemoMode && inputField != null) inputField.text = "";
            if (button != null) button.interactable = true;
            if (inputField != null) inputField.interactable = true;
        }

        private void OnDestroy()
        {
            sessionToken = null;
            if (button != null) button.onClick.RemoveListener(SendReply);
        }
    }
}
