using UnityEngine;
using System;

public class VolumeSettings : MonoBehaviour
{
    public static VolumeSettings Instance { get; private set; }

    public event Action<float> OnBgmVolumeChanged;
    public event Action<float> OnSeVolumeChanged;

    private const string BgmVolumeKey = "BgmVolume";
    private const string SeVolumeKey = "SeVolume";
    private const float DefaultVolume = 0.7f;

    public float BgmVolume { get; private set; }
    public float SeVolume { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
            LoadVolume();
        }
    }

    // 音量をロード
    private void LoadVolume()
    {
        BgmVolume = PlayerPrefs.GetFloat(BgmVolumeKey, DefaultVolume);
        SeVolume = PlayerPrefs.GetFloat(SeVolumeKey, DefaultVolume);
    }

    // BGMの音量を設定
    public void SetBgmVolume(float volume)
    {
        BgmVolume = volume;
        PlayerPrefs.SetFloat(BgmVolumeKey, volume);
        PlayerPrefs.Save();
        OnBgmVolumeChanged?.Invoke(volume);
    }

    // SEの音量を設定
    public void SetSeVolume(float volume)
    {
        SeVolume = volume;
        PlayerPrefs.SetFloat(SeVolumeKey, volume);
        PlayerPrefs.Save();
        OnSeVolumeChanged?.Invoke(volume);
    }
}
