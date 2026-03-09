using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoader : MonoBehaviour
{
	public static void Load()
	{
		SceneManager.LoadScene(SceneNames.MainGame);
	}
}
