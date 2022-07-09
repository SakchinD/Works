using UnityEngine;
using DG.Tweening;
public class PlayerLookAt : MonoBehaviour
{
    [Header("0 = instantly")]
    [SerializeField] private float _rotateSpeed;
    
    public void PlayerRotate(Vector3 pos)
    {
        transform.DOLookAt(pos,_rotateSpeed);
    }
}
