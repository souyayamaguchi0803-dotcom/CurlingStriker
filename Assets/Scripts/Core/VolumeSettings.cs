using UnityEngine;

public class VolumeSettings : MonoBehaviour
{
    public static VolumeSettings Instance { get; private set; }
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource seSource;

    private const string BgmVolumeKey = "BgmVolume";
    private const string SeVolumeKey = "SeVolume";
    private const float DefaultVolume = 0.7f;

    public float BgmVolume => bgmSource.volume;
    public float SeVolume => seSource.volume;

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
        bgmSource.volume = PlayerPrefs.GetFloat(BgmVolumeKey, DefaultVolume);
        seSource.volume = PlayerPrefs.GetFloat(SeVolumeKey, DefaultVolume);
    }

    // BGMの音量を設定
    public void SetBgmVolume(float volume)
    {
        bgmSource.volume = volume;
        PlayerPrefs.SetFloat(BgmVolumeKey, volume);
        PlayerPrefs.Save();
    }

    // SEの音量を設定
    public void SetSeVolume(float volume)
    {
        seSource.volume = volume;
        PlayerPrefs.SetFloat(SeVolumeKey, volume);
        PlayerPrefs.Save();
    }
}
