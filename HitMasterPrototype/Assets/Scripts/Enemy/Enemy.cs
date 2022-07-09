using System;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] Rigidbody[] _rbList;
    Animator _animator;
    bool isDead;
    [SerializeField] float _hp;
    float _hpMax;
    public Slider slider;
    public Collider col;
    public int platformNum;
    public event Action<int,Enemy> hitEvent;
    public Animator animator { get { return _animator = _animator ?? GetComponent<Animator>(); } }
    private void Awake()
    {
        for(int i = 0; i < _rbList.Length; i++)
        {
            _rbList[i].isKinematic = true;
        }
        _hpMax = _hp;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Laser") && !isDead)
        {
            CheckDemage();
        }
    }
    public void CheckDemage()
    {
        _hp--;
        slider.value = _hp/_hpMax;
        if(_hp <= 0)
        {
            isDead = true;
            hitEvent(platformNum, this);
            col.enabled = false;
            slider.gameObject.SetActive(false);
            animator.enabled = false;
            KinematicOff();
        }
    }
    void KinematicOff()
    {
        for (int i = 0; i < _rbList.Length; i++)
        {
            _rbList[i].isKinematic = false;
        }
    }
}
