using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHeadHp : MonoBehaviour
{
    [SerializeField]  float _score;
    [SerializeField]  int _hp;
    Animator _animator;
    BoxCollider2D _collider2D;
    public Animator animator { get { return _animator = _animator ?? GetComponent<Animator>(); } }
    public BoxCollider2D bCollider2D { get { return _collider2D = _collider2D ?? GetComponent<BoxCollider2D>(); } }
    private bool _explosion;
    protected void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Bullet"))
        {
            AudioManager.Instence.AudioPlay("Impact0");
            GetDemage();
        }
    }

    private void GetDemage()
    {
        _hp--;
        if (_hp <= 0)
        {
            if (!_explosion)
            {
                LevelManager.Instence.GetScore(_score);
                var exp = ObjectPool.Instence.GetPooledObject("Med");
                exp.transform.position = transform.position;
                exp.SetActive(true);
                _explosion = true;
                AudioManager.Instence.AudioPlay("expS_1");
            }
            bCollider2D.enabled = false;
            animator.Play("Dead");
        }
    }
}
