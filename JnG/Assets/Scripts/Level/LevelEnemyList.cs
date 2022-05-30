using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelEnemyList : ScriptableObject
{
    [Serializable]
    public struct EnemyList
    {
        public string name;
        public float time;
        public int posNumb;
    }
    public List<EnemyList> list = new List<EnemyList>(); 
}