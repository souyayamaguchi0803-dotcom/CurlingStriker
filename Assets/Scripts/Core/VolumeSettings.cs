using UnityEngine;
using System;

public static class VolumeSettings
{
    public static event Action<float> OnBgmVolumeChanged;
    public static event Action<float> OnSeVolumeChanged;

    private const string BgmVolumeKey = "BgmVolume";
    private const string SeVolumeKey = "SeVolume";
    private const float DefaultVolume = 0.7f;

    public static float BgmVolume { get; private set; }
    public static float SeVolume { get; private set; }

    // 初回アクセス時に音量をロード
    static VolumeSettings()
    {
        BgmVolume = PlayerPrefs.GetFloat(BgmVolumeKey, DefaultVolume);
        SeVolume = PlayerPrefs.GetFloat(SeVolumeKey, DefaultVolume);
    }

    // BGMの音量を設定
    public static void SetBgmVolume(float volume)
    {
        BgmVolume = volume;
        PlayerPrefs.SetFloat(BgmVolumeKey, volume);
        PlayerPrefs.Save();
        OnBgmVolumeChanged?.Invoke(volume);
    }

    // SEの音量を設定
    public static void SetSeVolume(float volume)
    {
        SeVolume = volume;
        PlayerPrefs.SetFloat(SeVolumeKey, volume);
        PlayerPrefs.Save();
        OnSeVolumeChanged?.Invoke(volume);
    }
}
