using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : Singleton<GameManager>
{
    public bool inPauseState { get; private set; }
    public void StartPause()
    {        
        AudioManager.Instence.AudioPause("Level");
        inPauseState = true;
    }
    public void EndPause()
    {
        AudioManager.Instence.AudioPlay("Level");
        inPauseState = false;
    }
}
