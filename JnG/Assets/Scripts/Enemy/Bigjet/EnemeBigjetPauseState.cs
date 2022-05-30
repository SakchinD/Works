using UnityEngine;

public class EnemeBigjetPauseState : EnemyBaseState
{
    public override void EnterState(Enemy_Fsm enemy)
    { 
        (enemy as EnemyBigjet_Fsm).animator.speed = 0;
    }

    public override void OnBecameInvisible(Enemy_Fsm enemy)
    {
        
    }

    public override void OnTriggerEnter2D(Enemy_Fsm enemy, Collider2D col)
    {
        
    }

    public override void Update(Enemy_Fsm enemy)
    {
        if (!GameManager.Instence.inPauseState)
        {
            (enemy as EnemyBigjet_Fsm).PreviosState();
            (enemy as EnemyBigjet_Fsm).animator.speed = 1;
        }
    }
}