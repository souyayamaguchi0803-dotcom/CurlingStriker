using UnityEngine;

// タイトル用BGMを設定する
public class TitleBGMSetter : MonoBehaviour
{
    [SerializeField] private AudioClip titleBGM;

    void Start()
    {
        SoundSpeaker.Instance.PlayBGM(titleBGM);
    }
}
