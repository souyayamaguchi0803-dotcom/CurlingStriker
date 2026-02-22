using UnityEngine;

// タイトル用BGMを設定する
public class TitleBGMSetter : MonoBehaviour
{
    [SerializeField] private AudioClip titleBGM;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SoundSpeaker.Instance.PlayBGM(titleBGM);
    }
}
