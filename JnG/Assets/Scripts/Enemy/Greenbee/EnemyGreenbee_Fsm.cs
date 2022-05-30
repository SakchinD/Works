using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGreenbee_Fsm : Enemy_Fsm
{
    internal bool startRotate;
    internal float rotateAngle;
    public GameObject efire;
    public bool goBack,goDown;
    public float timeToUp, rotateSpeed, angleLimit, upSpeed;
    [SerializeField] Transform _barrel;
    private Quaternion _startRotation;
    private float _startTimeToUp,_startRotateAngle;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private BoxCollider2D _collider2D;
    public readonly EnemyGreenbeeMoveState moveState = new EnemyGreenbeeMoveState();
    public readonly EnemyGreenbeeDeadState deadState = new EnemyGreenbeeDeadState();
    public readonly EnemeGreembeePauseState pauseState = new EnemeGreembeePauseState();
    public BoxCollider2D bCollider2D { get { return _collider2D = _collider2D ?? GetComponent<BoxCollider2D>(); } }
    public Animator animator { get { return _animator = _animator ?? GetComponent<Animator>(); } }
    public Rigidbody2D rbody { get { return _rigidbody2D = _rigidbody2D ?? GetComponent<Rigidbody2D>(); } }
    private new void Awake()
    {
        _enemyMaxHp = _enemyHp;
        _startTimeToUp = timeToUp;
        _startRotation = transform.rotation;
        _startRotateAngle = rotateAngle;
        if(goDown)
        {
            upSpeed = -upSpeed;
        }
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
        transform.rotation = _startRotation;
        timeToUp = _startTimeToUp;
        rotateAngle = _startRotateAngle;
        startRotate = false;
        BaseRestore();
    }
    public void Fire()
    {
        var bullet = ObjectPool.Instence.GetPooledObject("BEnemy");
        bullet.transform.position = _barrel.position;
        bullet.transform.rotation = transform.rotation;
        bullet.gameObject.SetActive(true);
    }
}
