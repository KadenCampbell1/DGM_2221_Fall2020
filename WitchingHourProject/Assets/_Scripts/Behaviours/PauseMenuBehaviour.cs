using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuBehaviour : MonoBehaviour
{
    public BoolData gamePaused;
    public GameObject pauseMenu;
    public GameAction gameAction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused.value)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
                gameAction.Raise();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        gamePaused.value = false;
    }

    private void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        gamePaused.value = true;
    }
}
