using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
	public static void StartNewGame()
	{
		SceneManager.LoadScene(SceneNames.MainGame);
	}
}

