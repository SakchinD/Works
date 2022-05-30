using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHabitatMoveState : EnemyBaseState
{
    public override void EnterState(Enemy_Fsm enemy)
    {
        
    }

    public override void OnBecameInvisible(Enemy_Fsm enemy)
    {
        (enemy as EnemyHabitat_Fsm).Restor();
    }

    public override void OnTriggerEnter2D(Enemy_Fsm enemy, Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            (enemy as EnemyHabitat_Fsm).CheckDemage();
        }
    }

    public override void Update(Enemy_Fsm enemy)
    {
        EnemyHabitat_Fsm thisEnemy = (EnemyHabitat_Fsm)enemy;

        thisEnemy.transform.position += new Vector3(-thisEnemy.speed, 0, 0) * Time.deltaTime;
        thisEnemy.transform.Rotate(Vector3.forward * thisEnemy.rotateSpeed * Time.deltaTime);
        if(GameManager.Instence.inPauseState)
        {
            thisEnemy.TransitionToState(thisEnemy.pauseState);
        }
    }
}
