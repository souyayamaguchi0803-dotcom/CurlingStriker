using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// 音量設定を操作する
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (SoundSpeaker.Instance != null)
        {
            bgmSlider.value = VolumeSettings.Instance.BgmVolume;
            seSlider.value = VolumeSettings.Instance.SeVolume;
        }

        bgmSlider.onValueChanged.AddListener(OnBgmVolumeChanged);
        seSlider.onValueChanged.AddListener(OnSeVolumeChanged);
    }

    // BGMの音量設定
    private void OnBgmVolumeChanged(float value)
    {
        if (SoundSpeaker.Instance != null)
        {
            VolumeSettings.Instance.SetBgmVolume(value);
        }
    }

    // SEの音量設定
    private void OnSeVolumeChanged(float value)
    {
        if (SoundSpeaker.Instance != null)
        {
            VolumeSettings.Instance.SetSeVolume(value);
        }
    }
}
