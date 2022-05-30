using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : Singleton<AudioManager>
{
    [Serializable]
    public struct KeyValue
    {
        public string Key;
        public AudioSource Audio;
    }
    public List<KeyValue> audioSources = new List<KeyValue>();
    public void AudioPlay(string key)
    {
        var obj = audioSources.Find(item => item.Key == key);
        obj.Audio?.Play();
    }
    public void AudioPause(string key)
    {
        var obj = audioSources.Find(item => item.Key == key);
        obj.Audio?.Pause();
    }
}
