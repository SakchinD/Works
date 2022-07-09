using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] float _speed,_force;
    Rigidbody _rb;
    public Rigidbody rb { get { return _rb = _rb ?? GetComponent<Rigidbody>(); } }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * _speed, ForceMode.Acceleration);
    }
    private void OnCollisionEnter(Collision col)
    {
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
        if (col.collider.CompareTag("Enemy"))
        {
            if (col.collider.enabled)
            {
                col.collider.attachedRigidbody.isKinematic = false;
                col.collider.attachedRigidbody.AddForce(transform.up + transform.forward * _force, ForceMode.Impulse);              
            }
        }
        gameObject.SetActive(false);

    }
}
