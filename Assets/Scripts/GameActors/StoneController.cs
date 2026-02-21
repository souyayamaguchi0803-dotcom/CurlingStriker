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
        if (HasAccelerateInput)
        {
            if (referee != null && referee.CanAccelerate())
            {
                stone.TryAccelerate();
            }
        }
    }

    private bool HasAccelerateInput => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);
}
