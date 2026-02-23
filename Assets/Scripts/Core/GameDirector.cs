using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isInGame = true;
    private GameReferee gameReferee;
    [SerializeField] private GameResult result;
    [SerializeField] private Stone stone;
    [SerializeField] private StoneController stoneController;
    [SerializeField] private GameObject line;
    [SerializeField] private AudioClip gameBGM;

    void Start()
    {
        gameReferee = new GameReferee(stone, line);
        stoneController.SetReferee(gameReferee);
        SoundSpeaker.Instance.PlayBGM(gameBGM);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInGame && gameReferee.IsGameOver())
        {
            OnGameOver();
        }
    }

    // ゲームオーバーになったら1度だけ呼ばれる
    void OnGameOver()
    {
        result.EndGame();
        isInGame = false;
    }
}
