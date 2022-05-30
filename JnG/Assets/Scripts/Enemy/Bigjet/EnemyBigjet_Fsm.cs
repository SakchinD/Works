using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigjet_Fsm : Enemy_Fsm
{
    internal bool startRotate;
    public GameObject efire;
    public float downSpeed, timeToDown;
    [SerializeField] Transform[] _rocketPos;
    private float _startTimeToDown;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private BoxCollider2D _collider2D;
    public readonly EnemyBigjetMoveState moveState = new EnemyBigjetMoveState();
    public readonly EnemyBigjetDeadState deadState = new EnemyBigjetDeadState();
    public readonly EnemeBigjetPauseState pauseState = new EnemeBigjetPauseState();
    public BoxCollider2D bCollider2D { get { return _collider2D = _collider2D ?? GetComponent<BoxCollider2D>(); } }
    public Animator animator { get { return _animator = _animator ?? GetComponent<Animator>(); } }
    public Rigidbody2D rbody { get { return _rigidbody2D = _rigidbody2D ?? GetComponent<Rigidbody2D>(); } }
    private new void Awake()
    {
        _enemyMaxHp = _enemyHp;
        _startTimeToDown = timeToDown;
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
        animator.Play("Normal");
        efire.SetActive(true);
        rbody.isKinematic = true;        
        TransitionToState(moveState);
        bCollider2D.enabled = true;
        timeToDown = _startTimeToDown;
        startRotate = false;
        BaseRestore();
    }
    public void FireRockets()
    {
        for(int i =0;i<_rocketPos.Length;i++)
        {
            var rocket = ObjectPool.Instence.GetPooledObject("BigjetRocket");
            rocket.transform.position = _rocketPos[i].position;
            rocket.gameObject.SetActive(true);            
        }
        if (AudioManager.Instence)
        {
            AudioManager.Instence.AudioPlay("airair");
        }
    }
}
