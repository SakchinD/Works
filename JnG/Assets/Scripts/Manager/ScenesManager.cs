using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : Singleton<ScenesManager>
{
    public void StartGame()
    {
        SceneManager.LoadScene("LoadSceneGame");
    }
    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
    public void ToMainMenu()
    {
        SceneManager.LoadScene("LoadStartMenu");
    }
}
