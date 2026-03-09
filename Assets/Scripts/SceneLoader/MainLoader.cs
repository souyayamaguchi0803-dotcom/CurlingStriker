using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoader : MonoBehaviour
{
	public static void StartNewGame()
	{
		SceneManager.LoadScene(SceneNames.MainGame);
	}
}

