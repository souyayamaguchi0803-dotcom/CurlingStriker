using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject house;

    public Score Calculate()
    {
        float distance = Vector2.Distance(stone.transform.position, house.transform.position);
        return new Score(distance);
    }
}
