using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
    public abstract void EnterState(PlayerControl_Fsm player);
    public abstract void Update(PlayerControl_Fsm player);
    public abstract void OnTriggerEnter2D(PlayerControl_Fsm player, Collider2D col);
    public abstract void OnCollisionEnter2D(PlayerControl_Fsm player, Collision2D col);    
}
