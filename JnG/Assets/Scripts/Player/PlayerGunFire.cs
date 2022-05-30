using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunFire : MonoBehaviour
{
    [SerializeField] float _fireCdSecond;
    private bool _isFire;
    private string _ammoType;
    ParticleSystem _particleSystem;
    public ParticleSystem particle { get { return _particleSystem = _particleSystem??GetComponent<ParticleSystem>(); } }
    void Start()
    {
        _ammoType = "Bullet";
    }
    public void Fire()
    {
        if (!_isFire)
        {
            _isFire = true;
            var bullet = ObjectPool.Instence.GetPooledObject(_ammoType);
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.SetActive(true);
                particle.Play();
                AudioManager.Instence.AudioPlay("fire_impact");
                StartCoroutine(OnFireCD());
            }
        }
    }
    IEnumerator OnFireCD()
    {
        yield return new WaitForSeconds(_fireCdSecond);
        _isFire=false;
    }
}
