using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public Button pauseButton, resumeButton, toMainMenuButton;
    private PauseMenu _pauseMenu;
    public PauseMenu pauseMenu { get { return _pauseMenu=_pauseMenu ?? FindObjectOfType<PauseMenu>(); } }
    private void Awake()
    {
        pauseButton.onClick.AddListener(pauseClick);
        resumeButton.onClick.AddListener(resumeClick);
        toMainMenuButton.onClick.AddListener(toMainMenuClick);
    }
    private void toMainMenuClick()
    {
        ScenesManager.Instence.ToMainMenu();
    }

    private void resumeClick()
    {
        pauseMenu.HideMenu();
        GameManager.Instence.EndPause();
    }

    private void pauseClick()
    {
        pauseMenu.ShowMenu();
        GameManager.Instence.StartPause();
    }
    private void OnApplicationPause(bool pause)
    {
        if(pause)
        {
            pauseClick();
        }
    }
}
