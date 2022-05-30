using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCan_Fsm : Enemy_Fsm
{
    public float rotateSpeed, angleLimit;
    [HideInInspector]
    public float rotateAngle;
    public bool isUp;
    public readonly EnemyCanMoveState moveState = new EnemyCanMoveState();
    public readonly EnemyCanDeadState deadState = new EnemyCanDeadState();
    public readonly EnemyCanPauseState pauseState = new EnemyCanPauseState();
    private void Start()
    {
        TransitionToState(moveState);
    }
    public void CheckDemage()
    {
        DecreaseHp();
        if (_enemyHp <= 0)
        {
            TransitionToState(deadState);
        }
    }
    public void Restor()
    {
        rotateAngle = 0;
        TransitionToState(moveState);
        BaseRestore();
    }
}
