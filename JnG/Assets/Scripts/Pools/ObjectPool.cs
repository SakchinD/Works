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
    Dictionary<string, List<GameObject>> ammoDict = new Dictionary<string, List<GameObject>>();

    void CreateBullet(string ObjectName)
    {
        if (!ammoDict.ContainsKey(ObjectName))
        {
            ammoDict.Add(ObjectName, new List<GameObject>());
        }
        var obj = objects.Find(item => item.ObjectName == ObjectName);
        if (obj.Object)
        {
            var _bullet = Instantiate(obj.Object);
            _bullet.transform.SetParent(transform);
            _bullet.gameObject.SetActive(false);
            ammoDict[ObjectName].Add(_bullet);
        }
    }
    public GameObject GetPooledObject(string ObjectName)
    {
        if (ammoDict.ContainsKey(ObjectName))
        {
            for (int i = 0; i < ammoDict[ObjectName].Count; i++)
            {
                if (!ammoDict[ObjectName][i].gameObject.activeInHierarchy)
                {
                    return ammoDict[ObjectName][i];
                }
            }
        }
        CreateBullet(ObjectName);
        if (ammoDict[ObjectName].Count > 0)
        {
            return ammoDict[ObjectName][ammoDict[ObjectName].Count - 1];
        }
        else
        {
            return null;
        }
    }
}
