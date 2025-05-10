using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;

public class FMImageAdjust : MonoBehaviour
{
    public Animator fade;
    public Animator cgFade;
    public Sprite[] cgs;

    public GameObject imageObjectCG;
    public Image imageComponentCG;

    public Sprite cgSprite;

    public Sprite[] bgs;

    public GameObject imageObjectBG;
    public Image imageComponentBG;

    public Sprite bgSprite;


    public void Start()
    {

        imageComponentCG = imageObjectCG.GetComponent<Image>();
        cgSprite = imageComponentCG.sprite;
        imageComponentBG = imageObjectBG.GetComponent<Image>();
        bgSprite = imageComponentBG.sprite;
    }
    [YarnCommand("bgswitch")]
    public void BGSwitch(string name)
    {
        for (int i = 0; i < bgs.Length; i++)
        {
            if (bgs[i].name == name)
            {
                imageComponentBG.sprite = bgs[i];
            }
        }
    }
    [YarnCommand("cgswitch")]
    public void CGSwitch(string name)
    {
        for (int i = 0; i < cgs.Length; i++)
        {
            if (cgs[i].name == name)
            {
                imageComponentCG.sprite = cgs[i];
            }
        }
        cgFade.SetTrigger("CGFadeIn");
        cgFade.ResetTrigger("CGFadeOut");
    }
    [YarnCommand("cgoff")]
    public void CGOff()
    {
        cgFade.SetTrigger("CGFadeOut");
        cgFade.ResetTrigger("CGFadeIn");
    }

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
