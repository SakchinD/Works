using UnityEngine;

public class EnemyBigjetMoveState : EnemyBaseState
{
    public override void EnterState(Enemy_Fsm enemy)
    {
        
    }

    public override void OnBecameInvisible(Enemy_Fsm enemy)
    {
        (enemy as EnemyBigjet_Fsm).Restor();
    }

    public override void OnTriggerEnter2D(Enemy_Fsm enemy, Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            (enemy as EnemyBigjet_Fsm).CheckDemage();
        }
    }

    public override void Update(Enemy_Fsm enemy)
    {
        EnemyBigjet_Fsm thisEnemy = (EnemyBigjet_Fsm)enemy;
        thisEnemy.timeToDown -= Time.deltaTime;
        if (thisEnemy.timeToDown < 0)
        {
           thisEnemy.startRotate = true;
           thisEnemy.animator.Play("MoveDown");
           thisEnemy.transform.Translate(Vector2.down * thisEnemy.downSpeed * Time.deltaTime);
        }
       thisEnemy.Move();

        if (GameManager.Instence.inPauseState)
        {
           thisEnemy.TransitionToState(thisEnemy.pauseState);
        }
    }
}