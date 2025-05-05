using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class StopPlayMusic : MonoBehaviour
{
    public AudioSource turnon;
    public AudioSource turnoff;
    public AudioClip[] adventureMusic;

    [YarnCommand("stopbgm")]
    public void AdjustMusic()
    {
        turnoff.Stop();
        turnon.Play();
    }

    [YarnCommand("switchtracks")]
    public void ScriptMusicControl(string title)
    {
        turnon.Stop();
        for (int i = 0; i < adventureMusic.Length; i++)
        {
            if (adventureMusic[i].name == title)
            {
                turnon.clip = adventureMusic[i];
            }
        }
        turnon.Play();


    }
}
