using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleHp : ObstacleOnTopHp
{ 
    protected new void GetDemage()
    {
        _hp--;
        if (_hp <= 0)
        {            
            var s = GetComponentsInChildren<ObstacleOnTopHp>();
            for (int i = 0; i < s.Length; i++)
            {
                s[i].GetDestroy();
            }
            GetDestroy();
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            AudioManager.Instence.AudioPlay("Impact0");
            GetDemage();
        }
    }
}
