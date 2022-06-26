using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Wheat : MonoBehaviour
{
    [SerializeField] int _growCD;
    [SerializeField] Collider _col;
    Vector3 _startScale;
    private void Awake()
    {
        _startScale = transform.localScale;
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Sick"))
        {
            _col.enabled = false;
            CreatePackage();
            var fx = ObjectPool.Instence.GetPooledObject("FX");
            fx.transform.position = other.transform.position;
            fx.SetActive(true);
            transform.DOScale(Vector3.zero,0.5f);
            StartCoroutine(StartGrow());
        }
    }
    void CreatePackage()
    {
        var pac = ObjectPool.Instence.GetPooledObject("WheatP");
        pac.transform.position = transform.position;
        pac.SetActive(true);
    }
    IEnumerator StartGrow()
    {
        yield return new WaitForSeconds(_growCD);
        _col.enabled = true;
        transform.DOScale(_startScale, 0.5f);
    }
}
