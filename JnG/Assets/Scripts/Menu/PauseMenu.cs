using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private Animator _animator;
    public Animator animator { get { return _animator = _animator ?? GetComponent<Animator>(); } }

    public void HideMenu()
    {
        animator.Play("PauseEnd");
        AudioManager.Instence.AudioPlay("menu");
    }
    public void ShowMenu()
    {
        animator.Play("PauseStart");
        AudioManager.Instence.AudioPlay("menu");
    }
}
