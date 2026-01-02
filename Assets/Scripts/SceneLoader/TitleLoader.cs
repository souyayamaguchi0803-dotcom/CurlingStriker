using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLoader : MonoBehaviour
{
    public static void LoadTitleScene()
    {
        SceneManager.LoadScene(SceneNames.Title);
    }
}
