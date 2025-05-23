using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
public class ExpressionChange : MonoBehaviour
{
    public GameObject imageObject;

    public Sprite[] spriteArray;

    private Image imageComponent;

    public Sprite expressionSprite;

    public Animator spriteAnimator;
    public void Start()
    {

        imageComponent = imageObject.GetComponent<Image>();
        expressionSprite = imageComponent.sprite;

    }
    [YarnCommand("expr")]
    public void Expression(string expression)
    {
        for (int i = 0; i < spriteArray.Length; i++)
        {
            if (spriteArray[i].name == expression)
            {
                imageComponent.sprite = spriteArray[i];
            }
        }
    }
    [YarnCommand("spriteoff")]
    public void SpriteOff()
    {
        spriteAnimator.SetTrigger("SpriteFadeOut");
        spriteAnimator.ResetTrigger("SpriteFadeIn");

    }
    [YarnCommand("spriteon")]
    public void SpriteOn()
    {
        spriteAnimator.SetTrigger("SpriteFadeIn");
        spriteAnimator.ResetTrigger("SpriteFadeOut");
    }
}
