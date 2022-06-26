using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class StackController : MonoBehaviour
{
    [SerializeField] CoinController _coin;
    [SerializeField] Slider _slider;
    [SerializeField] TMP_Text _textCount, _fullText;
    [SerializeField] float _stackStepHeight;
    bool _isSale;

    [Header("Float, 0 = instantly")]
    public float packageSpeed;

    [Header("Float ,Delay between packege, in second")]
    public float delay;

    [HideInInspector] public float stackCount;
    [HideInInspector] public float stackHeight;
    public Transform barn;
    public float stackMaxCount;
    public List<WheatPackage> wheatPackageList = new List<WheatPackage>();

    void Update()
    {
        _slider.value = stackCount / stackMaxCount;
        _textCount.text = $"{stackCount}/{stackMaxCount}";
        if (stackCount == stackMaxCount)
        {
            _fullText.gameObject.SetActive(true);
        }
        else
        {
            _fullText.gameObject.SetActive(false);
        }
    }

    public void StackUP()
    {
        stackCount++;
        stackHeight += _stackStepHeight;
    }

    public void SaleWheat()
    {
        if (wheatPackageList.Count > 0)
        {
            var s = wheatPackageList[wheatPackageList.Count - 1];
            wheatPackageList.Remove(s);
            stackCount--;
            stackHeight -= _stackStepHeight;
            var seq = DOTween.Sequence();
            s.transform.SetParent(ObjectPool.Instence.transform);
            seq.Append(s.transform.DOMove(barn.position, packageSpeed));
            seq.OnComplete(s.Restore);
            StartCoroutine(_coin.CoinMove());
        }
    }

    public IEnumerator Sale()
    {
        if (!_isSale)
        {
            _isSale = true;
            SaleWheat();
            yield return new WaitForSeconds(delay);
            _isSale = false;
        }
        
    }
}
