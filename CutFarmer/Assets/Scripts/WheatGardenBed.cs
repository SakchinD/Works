using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatGardenBed : MonoBehaviour
{
    public GameObject wheat;
    public bool _canGrow;
    public bool _isGrow;
    private void Start()
    {
        Wheat();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Package") || other.CompareTag("Wheat"))
        {
            _canGrow = false;
        }
        else
        {
            _canGrow = true;
            StartCoroutine(StartGrow());
        }
    }
    
    IEnumerator StartGrow()
    {
        yield return new WaitForSeconds(0.4f);
        if(_canGrow && _isGrow)
        {
            _isGrow = false;
            yield return new WaitForSeconds(10);
            Wheat();
            _isGrow = true;
        }
    }
    void Wheat()
    {
        var wheat = ObjectPool.Instence.GetPooledObject("Wheat");
        wheat.SetActive(true);
        wheat.transform.position = transform.position;
    }
}
