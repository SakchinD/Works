using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunFire : MonoBehaviour
{
    Camera _camera;
    Vector3 _pos;
    private void Awake()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (GameManager.Instence.isStart)
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began)
                {
                    Ray ray = _camera.ScreenPointToRay(touch.position);
                    if (Physics.Raycast(ray, out RaycastHit hit))
                    {
                        _pos = hit.point - transform.position;
                    }
                    var laser = ObjectPool.Instence.GetPooledObject("Laser");
                    if (laser)
                    {
                        laser.transform.position = transform.position;
                        laser.SetActive(true);
                        laser.transform.rotation = Quaternion.LookRotation(_pos);
                    }
                }
            }
            //if (Input.GetButtonDown("Fire1"))
            //{
            //    Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            //    if (Physics.Raycast(ray, out RaycastHit hit))
            //    {
            //        _pos = hit.point - transform.position;
            //    }
            //    var laser = ObjectPool.Instence.GetPooledObject("Laser");
            //    if (laser)
            //    {

            //        laser.transform.position = transform.position;
            //        laser.SetActive(true);
            //        laser.transform.rotation = Quaternion.LookRotation(_pos);

            //    }
            //}
        }
    }
}
