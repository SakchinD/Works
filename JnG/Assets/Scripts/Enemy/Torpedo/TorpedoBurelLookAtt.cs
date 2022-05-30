using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoBurelLookAtt : MonoBehaviour
{
    [SerializeField] bool isUpBarrel;
    private PlayerControl_Fsm _player;
    public PlayerControl_Fsm player { get { return _player = _player ?? FindObjectOfType<PlayerControl_Fsm>(); } }

    private void Update()
    {
        Vector2 direction = transform.position - player.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if(isUpBarrel)
        {
            angle = Mathf.Clamp(angle, -180, 0);
        }
        else
        {
            angle = Mathf.Clamp(angle, 0, 180);
        }
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}