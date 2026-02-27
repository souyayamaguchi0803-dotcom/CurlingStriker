using UnityEngine;

// ゲームの審判
public class GameReferee
{
    private readonly Stone stone;
    private readonly GameObject line;

    public GameReferee(Stone stone, GameObject line)
    {
        this.stone = stone;
        this.line = line;
    }

    // 加速ができるか判定
    public bool AllowsAcceleration()
    {
        return !IsOverLine();
    }

    // ゲームは終了したか判定
    public bool IsGameOver()
    {
        return IsOverLine() && stone.IsStopped;
    }

    // ボーダーラインを超えたか判定
    bool IsOverLine()
    {
        if (line == null) return false; // lineが未設定の場合falseを返す
        return stone.CurrentX > line.transform.position.x;
    }
}
