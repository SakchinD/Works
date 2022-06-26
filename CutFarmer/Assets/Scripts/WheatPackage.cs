using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WheatPackage : MonoBehaviour
{
    [SerializeField] Collider _col;
    StackController _stack;
    public StackController stack { get { return _stack = _stack ?? FindObjectOfType<StackController>(); } }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            ToStack();          
        }
    }
    void ToStack()
    {
        if (stack.stackCount < stack.stackMaxCount)
        {

            _col.enabled = false;
            transform.SetParent(stack.transform);
            transform.DOLocalMove(new Vector3(0,stack.stackHeight,0), 0.5f);
            transform.DORotateQuaternion(stack.transform.rotation,0);
            stack.StackUP();
            stack.wheatPackageList.Add(this);
        }
    }
    public void Restore()
    {
        _col.enabled = true;
        gameObject.SetActive(false);
    }
}
