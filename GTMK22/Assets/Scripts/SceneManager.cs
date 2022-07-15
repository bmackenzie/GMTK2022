using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    [SerializeField] private int numScenes;


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadSpecificScene(string sceneName)
    {
        SetLastIndex();
        SceneManager.LoadScene(sceneName);
    }
}
