using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        Loader.Load(Loader.Scene.Room);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu() {
        Loader.Load(Loader.Scene.TitleScreen);
    }
}
