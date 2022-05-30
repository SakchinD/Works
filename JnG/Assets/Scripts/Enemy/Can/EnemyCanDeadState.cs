using UnityEngine;

public class EnemyCanDeadState : EnemyBaseState
{
    public override void EnterState(Enemy_Fsm enemy)
    {
        EnemyCan_Fsm thisEnemy = (EnemyCan_Fsm)enemy;
        LevelManager.Instence.GetScore(thisEnemy.score);
        thisEnemy.Explosion("Small");
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