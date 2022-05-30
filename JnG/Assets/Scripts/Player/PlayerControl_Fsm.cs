using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl_Fsm : MonoBehaviour
{
    public FloatingJoystick joystick;
    public PlayerGunFire barrel;
    public float yClampMin, yClampMax, speed, xClamp;
    [SerializeField] float _hp;
    public float hpMax { get; private set; }
    public event Action<float> currentHpEvent;
    private PlayerBaseState _currentState;
    public PlayerBaseState currentState { get { return _currentState; } }
    public readonly PlayerDeadState deadState = new PlayerDeadState();
    public readonly PlayerPauseState pauseState = new PlayerPauseState();
    public readonly PlayerMoveState moveState = new PlayerMoveState();
    public readonly PlayreClearState clearState = new PlayreClearState();
    Animator _animator;
    Rigidbody2D _rigidbody2D;
    public Animator animator { get { return _animator = _animator ?? GetComponent<Animator>(); } }
    public Rigidbody2D rb2D { get { return _rigidbody2D = _rigidbody2D ?? GetComponent<Rigidbody2D>(); } }
    private void Awake()
    {
        hpMax = _hp;
    }
    private void Start()
    {
        TrasitionToState(moveState);
    }
    private void Update()
    {
        currentState.Update(this);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        currentState.OnTriggerEnter2D(this,col);
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        currentState.OnCollisionEnter2D(this, col);
    }
    public void TrasitionToState(PlayerBaseState state)
    {
        _currentState = state;
        _currentState.EnterState(this);
    }
    public void GetDemage()
    {
        AudioManager.Instence.AudioPlay("HeroHit0");
        _hp--;
        currentHpEvent(_hp);
        if (_hp <= 0)
        {
            TrasitionToState(deadState);
        }
    }
    public void Move()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");
        //Vector2 move = new Vector2(horizontal, vertical) * Time.deltaTime * speed;
        Vector2 move = new Vector2(joystick.Horizontal, joystick.Vertical) * Time.deltaTime * speed;
        rb2D.velocity = move;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -xClamp, xClamp),
            Mathf.Clamp(transform.position.y, yClampMin, yClampMax));
        animator.SetFloat("Vertical", joystick.Vertical);
    }
    public void Fire()
    {
        barrel.Fire();
    }
}
