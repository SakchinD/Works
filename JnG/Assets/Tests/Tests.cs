using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class Tests
{
    BulletMove bullet;
    EnemyCan_Fsm can;

    [SetUp]
    public void Setup()
    {
        var s = (BulletMove)AssetDatabase.
            LoadAssetAtPath("Assets/Prefabs/Game/Ammo/Bullet.prefab",typeof(BulletMove));
        bullet = Object.Instantiate(s);
        bullet.transform.position = Vector2.left;

        var b = (EnemyCan_Fsm)AssetDatabase.
            LoadAssetAtPath("Assets/Prefabs/Game/Enemy/CanUp.prefab", typeof(EnemyCan_Fsm));
        can = Object.Instantiate(b);
        can.transform.position = Vector2.zero;
    }
    [TearDown]
    public void Teardown()
    {
        Object.Destroy(bullet.gameObject);
        Object.Destroy(can.gameObject);
    }

    [UnityTest]
    public IEnumerator BulletCollidesTest()
    {
        yield return new WaitForSeconds(3f);
        Assert.False(bullet.gameObject.activeSelf);
    }
    [UnityTest]
    public IEnumerator CanDestroyTest()
    {
        for(int i = 0; i < 5; i++)
        {
            Object.Instantiate(bullet);
        }
        yield return new WaitForSeconds(3f);
        Assert.False(bullet.gameObject.activeSelf);
    }
}
