using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

// 音量設定を操作する
public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider seSlider;

    void Start()
    {
        bgmSlider.value = VolumeSettings.BgmVolume;
        seSlider.value = VolumeSettings.SeVolume;

        bgmSlider.onValueChanged.AddListener(OnBgmVolumeChanged);
        seSlider.onValueChanged.AddListener(OnSeVolumeChanged);
    }

    // BGMの音量設定
    private void OnBgmVolumeChanged(float value)
    {
        VolumeSettings.SetBgmVolume(value);
    }

    // SEの音量設定
    private void OnSeVolumeChanged(float value)
    {
        VolumeSettings.SetSeVolume(value);
    }
}
