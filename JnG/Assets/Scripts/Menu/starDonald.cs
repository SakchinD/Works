using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starDonald : MonoBehaviour
{
    [SerializeField] float _speed;
    void Update()
    {
        if (!GameManager.Instence.inPauseState)
        {
            transform.Translate(Vector2.left * _speed * Time.deltaTime);
           
        }
    }
}
