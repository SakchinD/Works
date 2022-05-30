using UnityEngine;

public class EnemyCanMoveState : EnemyBaseState
{
    public override void EnterState(Enemy_Fsm enemy)
    {
        
    }
    public override void OnBecameInvisible(Enemy_Fsm enemy)
    {
        (enemy as EnemyCan_Fsm).Restor();
    }
    public override void OnTriggerEnter2D(Enemy_Fsm enemy, Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            (enemy as EnemyCan_Fsm).CheckDemage();
        }
    }

    public override void Update(Enemy_Fsm enemy)
    {
        EnemyCan_Fsm thisEnemy = (EnemyCan_Fsm)enemy;
        thisEnemy.rotateAngle += thisEnemy.isUp ?
            -(enemy as EnemyCan_Fsm).rotateSpeed : (enemy as EnemyCan_Fsm).rotateSpeed;

        thisEnemy.rotateAngle = Mathf.Clamp(thisEnemy.rotateAngle,
            -thisEnemy.angleLimit, thisEnemy.angleLimit);

        thisEnemy.Move();
        
        thisEnemy.transform.rotation = Quaternion.Euler
            (0, 0, thisEnemy.rotateAngle);   

        if (GameManager.Instence.inPauseState)
        {
            thisEnemy.TransitionToState(thisEnemy.pauseState);
        }
    }
}