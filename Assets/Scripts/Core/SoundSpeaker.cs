using UnityEngine;

// サウンド管理クラス
// シングルトンパターンで実装
public class SoundSpeaker : MonoBehaviour
{
    public static SoundSpeaker Instance { get; private set; }
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource seSource;

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
        }
    }

    private void Start()
    {
        // 起動時に、現在の設定値を読み込んでスピーカーに適用する
        bgmSource.volume = VolumeSettings.Instance.BgmVolume;
        seSource.volume = VolumeSettings.Instance.SeVolume;

        // 音量の設定の変化イベントを購読する
        VolumeSettings.Instance.OnBgmVolumeChanged += ApplyBgmVolume;
        VolumeSettings.Instance.OnSeVolumeChanged += ApplySeVolume;
    }

    // イベント受信時のメソッド
    private void ApplyBgmVolume(float volume)
    {
        bgmSource.volume = volume;
    }

    private void ApplySeVolume(float volume)
    {
        seSource.volume = volume;
    }

    // BGMを再生する
    public void PlayBGM(AudioClip clip)
    {
        // 既に流れているなら何もしない
        if (bgmSource.clip == clip && bgmSource.isPlaying) return;

        bgmSource.clip = clip;
        bgmSource.loop = true; // BGMなのでループさせる
        bgmSource.Play();
    }

    // SEを再生する
    public void PlaySE(AudioClip clip)
    {
        seSource.PlayOneShot(clip);
    }
}
