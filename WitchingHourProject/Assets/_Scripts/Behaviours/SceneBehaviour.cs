using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneBehaviour : MonoBehaviour
{
    public void OnQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnRestart(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
