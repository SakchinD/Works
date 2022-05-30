using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadindStartMenu : MonoBehaviour
{
    void Start()
    {
       SceneManager.LoadSceneAsync("StartMenu");
    }
}