using UnityEngine;
using UnityEngine.SceneManagement;
public class UiManager : MonoBehaviour
{

   
   public void RelodGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
            Application.Quit();
    #endif
    }

}
