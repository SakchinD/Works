using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinCountController : MonoBehaviour
{
    [Header("Coin multiple speed")]
    [SerializeField] float _multipleSpeed;

    [Header("Max value is 999999")]
    [SerializeField] int _maxCoinCount;
    [SerializeField] TMP_Text _coinNumbView;
    int _coinCount;
    private void Update()
    {
        _coinNumbView.text = $"{_coinCount}";
    }

    public IEnumerator CoinMultiple()
    {
        
        for(int i = 0; i < 15; i++)
        {
            _coinCount++;
            _coinCount = Mathf.Clamp(_coinCount, 0, _maxCoinCount);
            yield return new WaitForSeconds(_multipleSpeed);
        }
            
    }

}
