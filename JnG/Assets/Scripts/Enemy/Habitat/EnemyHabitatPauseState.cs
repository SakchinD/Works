using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHabitatPauseState : EnemyBaseState
{
    public override void EnterState(Enemy_Fsm enemy)
    {
        
    }

    public override void OnBecameInvisible(Enemy_Fsm enemy)
    {
        
    }

    public override void OnTriggerEnter2D(Enemy_Fsm enemy, Collider2D col)
    {
        
    }

    public override void Update(Enemy_Fsm enemy)
    {
        if(!GameManager.Instence.inPauseState)
        {
            (enemy as EnemyHabitat_Fsm).PreviosState();
        }
    }
}
