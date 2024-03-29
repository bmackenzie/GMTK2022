using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{

    [SerializeField] private int numScenes;

    private string currentScene = "";


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSpecificScene(string sceneName)
    {
        if (currentScene != "")
        {
            SceneManager.UnloadSceneAsync(currentScene);
        }
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        currentScene = sceneName;
    }
}
