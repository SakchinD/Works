using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyGreenbeeMoveState : EnemyBaseState
{
    public override void EnterState(Enemy_Fsm enemy)
    {        
                 
    }

    public override void OnBecameInvisible(Enemy_Fsm enemy)
    {
        (enemy as EnemyGreenbee_Fsm).Restor();
    }

    public override void OnTriggerEnter2D(Enemy_Fsm enemy, Collider2D col)
    {
        if(col.CompareTag("Bullet"))
        {
            (enemy as EnemyGreenbee_Fsm).CheckDemage();
        }
    }

    public override void Update(Enemy_Fsm enemy)
    {
        (enemy as EnemyGreenbee_Fsm).timeToUp -= Time.deltaTime;
        if ((enemy as EnemyGreenbee_Fsm).timeToUp <= 0)
        {           
            
            if ((enemy as EnemyGreenbee_Fsm).goBack)
            {
                (enemy as EnemyGreenbee_Fsm).rotateAngle += -(enemy as EnemyGreenbee_Fsm).rotateSpeed;
                (enemy as EnemyGreenbee_Fsm).rotateAngle = Mathf.Clamp((enemy as EnemyGreenbee_Fsm).rotateAngle, (enemy as EnemyGreenbee_Fsm).angleLimit, 0);
                (enemy as EnemyGreenbee_Fsm).transform.rotation = Quaternion.Euler(0, 0, (enemy as EnemyGreenbee_Fsm).rotateAngle);
            }
            else
            {
                (enemy as EnemyGreenbee_Fsm).startRotate = true;
                if ((enemy as EnemyGreenbee_Fsm).goDown)
                {
                    (enemy as EnemyGreenbee_Fsm).animator.Play("MoveDown");
                }
                else
                {
                    (enemy as EnemyGreenbee_Fsm).animator.Play("MoveUp");
                }
                (enemy as EnemyGreenbee_Fsm).transform.Translate(Vector2.up * (enemy as EnemyGreenbee_Fsm).upSpeed * Time.deltaTime);
            }
        }       
        (enemy as EnemyGreenbee_Fsm).Move();
        
        if(GameManager.Instence.inPauseState)
        {
            (enemy as EnemyGreenbee_Fsm).TransitionToState((enemy as EnemyGreenbee_Fsm).pauseState);
        }
    }
}