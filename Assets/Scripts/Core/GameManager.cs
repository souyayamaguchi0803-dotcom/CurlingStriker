using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isInGame = true;
    private GameOverChecker gameOverChecker;
    [SerializeField] private GameResult result;
    [SerializeField] private Stone stone;
    [SerializeField] private AudioClip gameBGM;

    void Start()
    {
        gameOverChecker = new GameOverChecker(stone);
        SoundManager.Instance.PlayBGM(gameBGM);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInGame && gameOverChecker.IsGameOver())
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
