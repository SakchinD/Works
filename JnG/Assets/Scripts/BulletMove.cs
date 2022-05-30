using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    [SerializeField] bool _isEnemy;
    [SerializeField] float _speed;
    private void Awake()
    {
        if(_isEnemy)
        {
            _speed = -_speed;
        }
    }
    void Update()
    {
        if (!GameManager.Instence.inPauseState)
        {

            transform.Translate(Vector3.right * _speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !_isEnemy)
        {
            Release();
        }
        else if (collision.CompareTag("Player") && _isEnemy)
        {
            Release();
        }
    }
    private void OnBecameInvisible()
    {
        Release();
    }

    private void Release()
    {
        gameObject.SetActive(false);
    }
}
