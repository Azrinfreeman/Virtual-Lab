using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public static class BioScoreLoader
{
    public static IEnumerator Load(TMP_Text label, string domain, int activity, bool quiz)
    {
        if (label == null) yield break;
        label.text = "Memuat...";
        int user = PlayerPrefs.GetInt("id_user");
        Uri endpoint;
        string address = (domain ?? "").TrimEnd('/') + (quiz ? "/fetchKuiz.php" : "/fetchEks.php");
        if (user <= 0 || !Uri.TryCreate(address, UriKind.Absolute, out endpoint) ||
            (endpoint.Scheme != "http" && endpoint.Scheme != "https"))
        {
            label.text = "Tidak tersedia";
            yield break;
        }
        var form = new WWWForm();
        form.AddField("_userid", user);
        form.AddField("_kuizNo", activity);
        using (var request = UnityWebRequest.Post(address, form))
        {
            request.timeout = 15;
            yield return request.SendWebRequest();
            if (label == null) yield break;
            int score;
            label.text = request.result == UnityWebRequest.Result.Success &&
                int.TryParse(request.downloadHandler.text.Trim(), out score) && score >= 0 && score <= 10
                ? score + " / 10" : "Tidak tersedia";
        }
    }
}
