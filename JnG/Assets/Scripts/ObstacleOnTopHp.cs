using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleOnTopHp : MonoBehaviour
{
    [SerializeField] protected float _score;
    [SerializeField] protected int _hp;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            AudioManager.Instence.AudioPlay("Impact0");
            GetDemage();
        }
    }
    internal void GetDestroy()
    {
        LevelManager.Instence.GetScore(_score);
        var exp = ObjectPool.Instence.GetPooledObject("Small");
        exp.transform.position = transform.position;
        exp.SetActive(true);
        AudioManager.Instence.AudioPlay("expS_1");
        Destroy(gameObject);
    }
    protected void GetDemage()
    {
        _hp--;
        if(_hp <= 0)
        {
            GetDestroy();
        }
    }
}
