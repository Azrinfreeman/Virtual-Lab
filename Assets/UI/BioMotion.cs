using System;
using UnityEngine;

public static class BioMotion
{
    const string PreferenceKey = "BioNutri.ReduceMotion";
    public static event Action Changed;
    public static bool Reduced => PlayerPrefs.GetInt(PreferenceKey, 0) != 0;

    public static void SetReduced(bool reduced)
    {
        if (Reduced == reduced) return;
        PlayerPrefs.SetInt(PreferenceKey, reduced ? 1 : 0);
        PlayerPrefs.Save();
        Changed?.Invoke();
    }

    public static float Ease(float t) => 1f - Mathf.Pow(1f - Mathf.Clamp01(t), 3f);
}
