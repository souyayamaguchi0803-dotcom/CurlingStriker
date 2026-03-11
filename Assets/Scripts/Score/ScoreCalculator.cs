using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject house;

    private Vector2 stonePosition => stone.transform.position;
    private Vector2 housePosition => house.transform.position;

    public Score Calculate()
    {
        float distance = Vector2.Distance(stonePosition, housePosition);
        return new Score(distance);
    }
}
