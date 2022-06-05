using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    [Serializable]
    public struct KeyValue
    {
        public string ObjectName;
        public GameObject Object;
    }
    public List<KeyValue> objects = new List<KeyValue>();
    private Dictionary<string, List<GameObject>> _ammoDict = new Dictionary<string, List<GameObject>>();

    void CreateBullet(string ObjectName)
    {
        var obj = objects.Find(item => item.ObjectName == ObjectName);
        if (obj.Object)
        {
            if (!_ammoDict.ContainsKey(ObjectName))
            {
                _ammoDict.Add(ObjectName, new List<GameObject>());
            }
            var bullet = Instantiate(obj.Object);
            bullet.transform.SetParent(transform);
            bullet.gameObject.SetActive(false);
            _ammoDict[ObjectName].Add(bullet);
        }
        else Debug.LogError("NO Object find");
    }
    public GameObject GetPooledObject(string ObjectName)
    {
        if (_ammoDict.ContainsKey(ObjectName))
        {
            for (int i = 0; i < _ammoDict[ObjectName].Count; i++)
            {
                if (!_ammoDict[ObjectName][i].gameObject.activeInHierarchy)
                {
                    return _ammoDict[ObjectName][i];
                }
            }
        }
        CreateBullet(ObjectName);
        if (_ammoDict.ContainsKey(ObjectName))
        {
            return _ammoDict[ObjectName][_ammoDict[ObjectName].Count - 1];
        }
        else
        {
            return null;
        }
    }
}
