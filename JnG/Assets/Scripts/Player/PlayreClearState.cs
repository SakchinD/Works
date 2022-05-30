using UnityEngine;

public class PlayreClearState : PlayerBaseState
{
    public override void EnterState(PlayerControl_Fsm player)
    {
        
    }

    public override void OnCollisionEnter2D(PlayerControl_Fsm player, Collision2D col)
    {
        
    }

    public override void OnTriggerEnter2D(PlayerControl_Fsm player, Collider2D col)
    {
        
    }

    public override void Update(PlayerControl_Fsm player)
    {
        player.Move();
    }
}