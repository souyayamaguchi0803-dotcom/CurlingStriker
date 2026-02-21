using UnityEngine;

public class StoneController : MonoBehaviour
{
    [SerializeField] private Stone stone;
    private GameReferee referee;

    public void SetReferee(GameReferee referee)
    {
        this.referee = referee;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (referee != null && referee.CanAccelerate())
            {
                stone.TryAccelerate();
            }
        }
    }
}
