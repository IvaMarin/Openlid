using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    public enum Scene
    {
        TitleScreen,
        Room,
        Islands,
        City,
        CreditsScreen,
        LoadingScreen
    }

    private static Action OnLoaderCallback;

    public static void Load(Scene scene)
    {
        OnLoaderCallback = () => {
            SceneManager.LoadScene(scene.ToString());
        };
        SceneManager.LoadScene(Scene.LoadingScreen.ToString());   
        
    }

    public static void LoaderCallback()
    {
        if (OnLoaderCallback != null) { 
            OnLoaderCallback();
            OnLoaderCallback = null;
        }
        
    }
}
