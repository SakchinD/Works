using UnityEngine;

public class EnemyTorpedoDeadState : EnemyBaseState
{
    public override void EnterState(Enemy_Fsm enemy)
    {
        EnemyTorpedo_Fsm thisEnemy = (EnemyTorpedo_Fsm)enemy;   

        LevelManager.Instence.GetScore(thisEnemy.score);
        thisEnemy.Explosion("Med");
        thisEnemy.animator.Play("Dead");
        thisEnemy.bCollider2D.enabled = false;
    }

    public override void OnBecameInvisible(Enemy_Fsm enemy)
    {
        (enemy as EnemyTorpedo_Fsm).Restor();
    }

    public override void OnTriggerEnter2D(Enemy_Fsm enemy, Collider2D col)
    {
        
    }

    public override void Update(Enemy_Fsm enemy)
    {
        (enemy as EnemyTorpedo_Fsm).transform.Translate
            (Vector3.down * (enemy as EnemyTorpedo_Fsm).deadDownSpeed * Time.deltaTime);
    }
}