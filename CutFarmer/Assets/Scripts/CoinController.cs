using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using DG.Tweening;

public class CoinController : MonoBehaviour
{ 
    Camera cam;
    [SerializeField] Image _coinIcon;
    [SerializeField] Transform _barnPos;
    [SerializeField] float _cdToCoinMove;
    [SerializeField] CoinCountController _coinCountController;
    private void Start()
    {
        cam = Camera.main;
    }
    public IEnumerator CoinMove()
    {
        yield return new WaitForSeconds(_cdToCoinMove);
        var pos = cam.ScreenToWorldPoint(new Vector3(_coinIcon.transform.position.x, _coinIcon.transform.position.y, cam.transform.position.z * 10));
        var coin = ObjectPool.Instence.GetPooledObject("Coin");
        coin.SetActive(true);
        coin.transform.position = _barnPos.position;

        var seq = DOTween.Sequence();
        seq.Append(coin.transform.DOMove(pos, 1f));
        seq.AppendCallback(() => coin.SetActive(false));
        seq.Append(_coinIcon.transform.DOShakeScale(0.05f,0.3f,1,10));
        seq.Append(_coinIcon.transform.DOScale(Vector3.one,0));
        seq.AppendCallback(() => StartCoroutine(_coinCountController.CoinMultiple()));
    }
}
