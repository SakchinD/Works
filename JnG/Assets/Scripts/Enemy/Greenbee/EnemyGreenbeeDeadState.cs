using UnityEngine;

public class EnemyGreenbeeDeadState : EnemyBaseState
{
    public override void EnterState(Enemy_Fsm enemy)
    {
        EnemyGreenbee_Fsm thisEnemy = (EnemyGreenbee_Fsm)enemy;

        LevelManager.Instence.GetScore(thisEnemy.score);
        thisEnemy.rbody.isKinematic = false;
        thisEnemy.efire.SetActive(false);
        thisEnemy.bCollider2D.enabled = false;
        thisEnemy.Explosion("Small");
        if(thisEnemy.startRotate)
        {
            thisEnemy.animator.Play("DeadUp");
        }
        else
        { 
            thisEnemy.animator.Play("Dead");
        }
    }

    public override void OnBecameInvisible(Enemy_Fsm enemy)
    {
        (enemy as EnemyGreenbee_Fsm).Restor();
    }

    public override void OnTriggerEnter2D(Enemy_Fsm enemy, Collider2D col)
    {
        
    }

    public override void Update(Enemy_Fsm enemy)
    {
        (enemy as EnemyGreenbee_Fsm).transform.Translate(Vector2.left * enemy.speed * Time.deltaTime);
    }
}