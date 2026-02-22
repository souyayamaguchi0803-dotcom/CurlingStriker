using UnityEngine;

// サウンド管理クラス
// シングルトンパターンで実装
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
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
            LoadVolume();
        }
    }

    /* ---音量の設定--- */
    private const string BgmVolumeKey = "BgmVolume";
    private const string SeVolumeKey = "SeVolume";
    private const float DefaultVolume = 0.7f;

    public float BgmVolume => bgmSource.volume;
    public float SeVolume => seSource.volume;

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

    // BGMの音量を設定
    public void SetSeVolume(float volume)
    {
        seSource.volume = volume;
        PlayerPrefs.SetFloat(SeVolumeKey, volume);
        PlayerPrefs.Save();
    }

    /* ---オーディオの再生--- */
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
