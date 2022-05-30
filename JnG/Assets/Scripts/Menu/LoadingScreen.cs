using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] string _sceneName;
    public Button button;
    private AsyncOperation _async;
    void Start()
    {            
        _async = SceneManager.LoadSceneAsync(_sceneName);
        _async.allowSceneActivation = false;      
    }
    private void Update()
    {
        if (_async.progress >=0.9f)
        {
            button.gameObject.SetActive(true);
        }
    }
    public void LoadScene()
    {
        _async.allowSceneActivation = true;
    }
}
