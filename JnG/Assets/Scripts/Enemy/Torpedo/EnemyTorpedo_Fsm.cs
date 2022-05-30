using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTorpedo_Fsm : Enemy_Fsm
{
    public Transform[] barrelsList;
    public float deadDownSpeed, cdFire;
    private float _cdFireStart;
    private bool _isDemaged;
    private Animator _animator;
    private BoxCollider2D _collider2D;
    public readonly EnemyTorpedoMoveState moveState = new EnemyTorpedoMoveState();
    public readonly EnemyTorpedoDeadState deadState = new EnemyTorpedoDeadState();
    public readonly EnemyTorpedoPauseState pauseState = new EnemyTorpedoPauseState();
    
    public BoxCollider2D bCollider2D { get { return _collider2D = _collider2D ?? GetComponent<BoxCollider2D>(); } }
    public Animator animator { get { return _animator = _animator ?? GetComponent<Animator>(); } }
    private new void Awake()
    {
        _enemyMaxHp = _enemyHp;
        _cdFireStart = cdFire;
    }
    private void Start()
    {
        TransitionToState(moveState);
    }
    public void CheckDemage()
    {
        DecreaseHp();
        if(_enemyHp <= _enemyMaxHp/2 && !_isDemaged)
        {
            animator.Play("Demaged");
            Explosion("Small");
            _isDemaged = true;
        }
        if (_enemyHp <= 0)
        {
            TransitionToState(deadState);
        }
    }
    public void Restor()
    {
        animator.Play("Normal");
        TransitionToState(moveState);
        bCollider2D.enabled = true;
        _isDemaged = false;
        cdFire = _cdFireStart;
        BaseRestore();
    }
    public void Fire()
    {
        for (int i = 0; i < barrelsList.Length; i++)
        {
            RaycastHit2D[] hitList = Physics2D.RaycastAll(barrelsList[i].position, -barrelsList[i].transform.right, LayerMask.GetMask("Player"));
            foreach (var s in hitList)
            {
                if (s.collider != null && s.collider.CompareTag("Player"))
                {
                    var bullet = ObjectPool.Instence.GetPooledObject("BEnemy");
                    bullet.transform.position = barrelsList[i].position;
                    bullet.transform.rotation = barrelsList[i].rotation;
                    bullet.SetActive(true);
                    cdFire = _cdFireStart;
                }
            }
        }     
    }
}