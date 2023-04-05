using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(sceneName);
    }


    public void ExitGame()
    {
    
        Application.Quit();
        Debug.Log("quit this app");

    }

}