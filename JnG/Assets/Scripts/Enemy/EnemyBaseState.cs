using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState 
{
    public abstract void EnterState(Enemy_Fsm enemy);
    public abstract void Update(Enemy_Fsm enemy);
    public abstract void OnTriggerEnter2D(Enemy_Fsm enemy, Collider2D col);
    public abstract void OnBecameInvisible(Enemy_Fsm enemy);
}
