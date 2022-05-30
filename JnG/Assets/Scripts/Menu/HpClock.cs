using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpClock : MonoBehaviour
{
    [SerializeField] float _minArrowAngle,_maxArrowAngle;
    private float _playerMaxHp;
    public RectTransform arrow;
    private PlayerControl_Fsm _player;
    public PlayerControl_Fsm player { get { return _player = _player ?? FindObjectOfType<PlayerControl_Fsm>(); } }
    private void Awake()
    {        
        player.currentHpEvent += Player_currentHpEvent;       
    }
    private void Start()
    {
        _playerMaxHp = player.hpMax;
        Player_currentHpEvent(_playerMaxHp);
    }
    private void Player_currentHpEvent(float hp)
    {
        arrow.localEulerAngles = new Vector3(0, 0,
            Mathf.Lerp(_minArrowAngle, _maxArrowAngle, hp / _playerMaxHp));
    }
}
