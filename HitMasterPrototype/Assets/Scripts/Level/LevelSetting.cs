using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelSetting : ScriptableObject
{
    [Serializable]
    public struct Positions
    {
        [Header("Number of planform")]
        public int platformNum;
        [Header("List of enemy positions")]
        public Vector3[] posList;
    }
    [Header("List of Platforms")]
    public List<Positions> platformsList = new List<Positions>();
}
