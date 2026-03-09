using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLoader : MonoBehaviour
{
    public static void Load()
    {
        SceneManager.LoadScene(SceneNames.Title);
    }
}
