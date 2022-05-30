using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHabitatDeadState : EnemyBaseState
{
    public override void EnterState(Enemy_Fsm enemy)
    {
        EnemyHabitat_Fsm thisEnemy = (EnemyHabitat_Fsm)enemy;

        LevelManager.Instence.GetScore(thisEnemy.score);
        LevelManager.Instence.HabitatLeftDecrease();
        enemy.Explosion("Med");
        thisEnemy.TransitionToState(thisEnemy.moveState);
        thisEnemy.Restor();
    }

    public override void OnBecameInvisible(Enemy_Fsm enemy)
    {
        
    }

    public override void OnTriggerEnter2D(Enemy_Fsm enemy, Collider2D col)
    {
        
    }

    public override void Update(Enemy_Fsm enemy)
    {
        
    }
}
