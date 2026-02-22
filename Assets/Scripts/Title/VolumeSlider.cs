using UnityEngine;
using UnityEngine.UI;

// 音量設定を操作する
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SoundManager.Instance != null)
        {
            bgmSlider.value = SoundManager.Instance.BgmVolume;
            seSlider.value = SoundManager.Instance.SeVolume;
        }

        bgmSlider.onValueChanged.AddListener(OnBgmVolumeChanged);
        seSlider.onValueChanged.AddListener(OnSeVolumeChanged);
    }

    // BGMの音量設定
    private void OnBgmVolumeChanged(float value)
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.SetBgmVolume(value);
        }
    }

    // SEの音量設定
    private void OnSeVolumeChanged(float value)
    {
        if (SoundManager.Instance != null)
        {
            SoundManager.Instance.SetSeVolume(value);
        }
    }
}
