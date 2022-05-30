using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerBaseState
{
    GameObject _exp;
    public override void EnterState(PlayerControl_Fsm player)
    {
        _exp = ObjectPool.Instence.GetPooledObject("Med");
        _exp.transform.position = player.transform.position;
        _exp.SetActive(true);
    }

    public override void OnCollisionEnter2D(PlayerControl_Fsm player, Collision2D col)
    {
        
    }

    public override void OnTriggerEnter2D(PlayerControl_Fsm player, Collider2D col)
    {
        
    }

    public override void Update(PlayerControl_Fsm player)
    {
       if (!_exp.activeSelf)
        {
            ScenesManager.Instence.GameOver();                
        }
    }
}
