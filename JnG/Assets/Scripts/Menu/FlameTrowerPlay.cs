using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameTrowerPlay : MonoBehaviour
{
    [SerializeField] float _minValue;
    [SerializeField] float _maxValue;
    ParticleSystem _particleSystem;
    public ParticleSystem particleSys
    { get { return _particleSystem = _particleSystem ?? GetComponent<ParticleSystem>(); } }
    private void Update()
    {
        if (particleSys.isStopped)
        {
            StartCoroutine(RandomParticlePlay());
        }    
    }
    IEnumerator RandomParticlePlay()
    {
        yield return new WaitForSeconds(Random.Range(_minValue,_maxValue));
        particleSys.Play();
    }
}
