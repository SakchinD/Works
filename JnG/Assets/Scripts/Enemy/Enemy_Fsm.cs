using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fsm : MonoBehaviour
{
    [SerializeField] protected int _enemyHp;
    protected int _enemyMaxHp;
    public float speed, score;
    protected Stack<EnemyBaseState> _statesStack = new Stack<EnemyBaseState>();
    protected EnemyBaseState _currentState;
    public EnemyBaseState currentState { get { return _currentState; } }
    protected void Awake()
    {
        _enemyMaxHp = _enemyHp;
    }
    protected void Update()
    {
        currentState.Update(this);
    }
    protected void OnBecameInvisible()
    {
        currentState.OnBecameInvisible(this);
    }
    protected void OnTriggerEnter2D(Collider2D col)
    {
        currentState.OnTriggerEnter2D(this, col);
    }
    public void TransitionToState(EnemyBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
        _statesStack.Push(state);
    }
    public void PreviosState()
    {
        _statesStack.Pop();
        _currentState = _statesStack.Peek();
        _currentState.EnterState(this);
    }
    public void Explosion(string str)
    {

        var exp = ObjectPool.Instence.GetPooledObject(str);
        if (exp)
        {
            exp.transform.position = transform.position;
            exp.SetActive(true);
            AudioManager.Instence.AudioPlay("expS_1");
        }
    }
    public void DecreaseHp()
    {
        AudioManager.Instence.AudioPlay("Impact0");
        _enemyHp--;
    }
    public void Move()
    {
        transform.Translate(Vector2.left *speed * Time.deltaTime);
    }
    public void BaseRestore()
    {
        _enemyHp = _enemyMaxHp;
        gameObject.SetActive(false);
    }
}
