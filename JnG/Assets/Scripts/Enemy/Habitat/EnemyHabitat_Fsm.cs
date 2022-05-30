using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHabitat_Fsm : Enemy_Fsm
{
    [SerializeField] Sprite[] _spriteList;
    [SerializeField] float _minSpeed, _maxSpeed;
    private SpriteRenderer _spriteRenderer;
    public float rotateSpeed;
    public readonly EnemyHabitatMoveState moveState = new EnemyHabitatMoveState();
    public readonly EnemyHabitatDeadState deadState = new EnemyHabitatDeadState();
    public readonly EnemyHabitatPauseState pauseState = new EnemyHabitatPauseState(); 
    public SpriteRenderer spriteRenderer { get { return _spriteRenderer = _spriteRenderer ?? GetComponent<SpriteRenderer>(); ; } }
    private new void Awake()
    {
        spriteRenderer.sprite = _spriteList[Random.Range(0, 4)];
        speed = Random.Range(_minSpeed, _maxSpeed);
        _enemyMaxHp = _enemyHp;
    }
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
        BaseRestore();
    }
}

