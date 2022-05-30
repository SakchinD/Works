using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgRepeat : MonoBehaviour
{
    [SerializeField] float _speed, _lenght;
    private float _newPos;
    private Vector3 _startPos;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instence.inPauseState)
        {
            _newPos = Mathf.Repeat(Time.time * -_speed, _lenght);
            transform.position = _startPos + _newPos * Vector3.right;
        }
    }
}
