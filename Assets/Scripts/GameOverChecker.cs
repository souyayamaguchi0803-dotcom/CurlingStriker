using UnityEngine;

public class GameOverChecker
{
    private readonly Stone stone;

    public GameOverChecker(Stone stone)
    {
        this.stone = stone;
    }

    public bool IsGameOver()
    {
        return stone.IsOverLine() && stone.IsStop();
    }
}
