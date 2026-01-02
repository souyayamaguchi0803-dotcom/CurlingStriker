using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isInGame = true;
    private GameOverChecker gameOverChecker;
    [SerializeField] private GameResult result;
    [SerializeField] private Stone stone;

    void Start()
    {
        gameOverChecker = new GameOverChecker(stone);
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
