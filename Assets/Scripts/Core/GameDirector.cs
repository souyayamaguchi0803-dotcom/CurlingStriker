using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
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
        // stoneControllerにgameRefereeについての依存性を注入
        gameReferee = new GameReferee(stone, line);
        stoneController.SetReferee(gameReferee);

        SoundSpeaker.Instance.PlayBGM(gameBGM);
    }

    void Update()
    {
        // ゲームが終了したらOnGameOver()を呼ぶ
        if (isInGame && gameReferee.DeclaresGameOver())
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
