using UnityEngine;

public class EnemyTorpedoMoveState : EnemyBaseState
{
    public override void EnterState(Enemy_Fsm enemy)
    {
        
    }

    public override void OnBecameInvisible(Enemy_Fsm enemy)
    {
        (enemy as EnemyTorpedo_Fsm).Restor();
    }

    public override void OnTriggerEnter2D(Enemy_Fsm enemy, Collider2D col)
    {
        if(col.CompareTag("Bullet"))
        {
            (enemy as EnemyTorpedo_Fsm).CheckDemage();
        }
    }

    public override void Update(Enemy_Fsm enemy)
    {
        EnemyTorpedo_Fsm thisEnemy = (EnemyTorpedo_Fsm)enemy;

        thisEnemy.Move();
        if (GameManager.Instence.inPauseState)
        {
            thisEnemy.TransitionToState(thisEnemy.pauseState);
        }
        thisEnemy.cdFire -= Time.deltaTime;
        if (thisEnemy.cdFire <= 0)
        {
            thisEnemy.Fire();
        }
    }
}