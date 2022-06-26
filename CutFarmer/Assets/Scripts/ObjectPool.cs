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
    private Dictionary<string, List<GameObject>> _objectDict = new Dictionary<string, List<GameObject>>();

    void CreateObject(string ObjectName)
    {
        var obj = objects.Find(item => item.ObjectName == ObjectName);
        if (obj.Object)
        {
            if (!_objectDict.ContainsKey(ObjectName))
            {
                _objectDict.Add(ObjectName, new List<GameObject>());
            }
            var inst = Instantiate(obj.Object);
            inst.transform.SetParent(transform);
            inst.gameObject.SetActive(false);
            _objectDict[ObjectName].Add(inst);
        }
        else Debug.LogError("NO Object find");
    }
    public GameObject GetPooledObject(string ObjectName)
    {
        if (_objectDict.ContainsKey(ObjectName))
        {
            for (int i = 0; i < _objectDict[ObjectName].Count; i++)
            {
                if (!_objectDict[ObjectName][i].gameObject.activeInHierarchy)
                {
                    return _objectDict[ObjectName][i];
                }
            }
        }
        CreateObject(ObjectName);
        if (_objectDict.ContainsKey(ObjectName))
        {
            return _objectDict[ObjectName][_objectDict[ObjectName].Count - 1];
        }
        else
        {
            return null;
        }
    }
}
