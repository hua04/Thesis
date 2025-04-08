using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Notifications : MonoBehaviour
{
    public Animator animator;
    public AudioSource sound;

    [YarnCommand("notif")]
   public void NotifOn()
    {
        animator.SetBool("MessagesUnread", true);
        sound.Play();
    }
    
    public void NotifOff()
    {
        animator.SetBool("MessagesUnread", false);
        sound.Stop();
    }
}
