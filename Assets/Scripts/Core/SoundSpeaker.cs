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
