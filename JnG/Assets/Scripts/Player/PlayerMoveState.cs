using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMoveState : PlayerBaseState
{
    public override void EnterState(PlayerControl_Fsm player)
    {
    }

    public override void OnCollisionEnter2D(PlayerControl_Fsm player, Collision2D col)
    {
        if (col.collider.CompareTag("Enemy") || col.collider.CompareTag("Shootable"))
        {           
            player.GetDemage();
        }
    }
    public override void OnTriggerEnter2D(PlayerControl_Fsm player, Collider2D col)
    {
        if (col.CompareTag("Enemy") || col.CompareTag("Shootable"))
        {
            player.GetDemage();
        }
    }

    public override void Update(PlayerControl_Fsm player)
    {
        player.Move();
      
        player.Fire();

        if(GameManager.Instence.inPauseState)
        {
            player.TrasitionToState(player.pauseState);
        }

        if(LevelManager.Instence.isCleared)
        {
            player.TrasitionToState(player.clearState);
        }
    }
}
