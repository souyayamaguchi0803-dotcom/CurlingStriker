using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    [SerializeField] private GameObject stone;
    [SerializeField] private GameObject house;

    public Score Calculate()
    {
        return new Score(stone.transform.position, house.transform.position);
    }
}
