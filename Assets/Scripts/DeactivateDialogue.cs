using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateDialogue : MonoBehaviour
{
    public GameObject canvas;
    public Animator anim;

    public void Start()
    {
        Close();
    }
    public void Close()
    {
        anim.SetTrigger("Close");
        anim.ResetTrigger("Open");
    }
    public void Open()
    {
        anim.SetTrigger("Open");
        anim.ResetTrigger("Close");
    }
}
