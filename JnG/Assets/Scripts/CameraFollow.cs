using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private void LateUpdate()
    {
        if (player.transform.position.y > transform.position.x)
        {
            transform.position = new Vector3(transform.position.x,
                Mathf.Clamp(player.transform.position.y, 0, 1), transform.position.z);
        }
    }
}
