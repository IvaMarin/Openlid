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

    public void LoadMainMenu()
    {
        Loader.Load(Loader.Scene.TitleScreen);
    }

    public void LoadRoom()
    {
        Loader.Load(Loader.Scene.Room);
    }

    public void LoadIslands()
    {
        Loader.Load(Loader.Scene.Islands);
    }

    public void LoadCity()
    {
        Loader.Load(Loader.Scene.City);
    }
}
