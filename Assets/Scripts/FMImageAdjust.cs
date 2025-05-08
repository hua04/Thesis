using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class FMImageAdjust : MonoBehaviour
{
    public Animator fade;
    public Sprite[] cgs;

    public GameObject imageObject;
    private Image imageComponent;

    public Sprite cgSprite;


    [YarnCommand("fmfadein")]
    public void FadeIn()
    {
        fade.SetTrigger("FMFadeIn");
        fade.ResetTrigger("FMFadeOut");
    }
    [YarnCommand("fmfadeout")]
    public void FadeOut()
    {
        fade.SetTrigger("FMFadeOut");
        fade.ResetTrigger("FMFadeIn");
    }
}
