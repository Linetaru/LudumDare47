using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource musicMenu;
    public AudioSource musicLevel;

    public AudioSource sfxCubeRouge;
    public AudioSource sfxCubeBleu;
    public AudioSource sfxCubeBlanc;
    public AudioSource sfxCubeTemporel;
    
    public AudioSource sfxReset;
    public AudioSource sfxDoor;
    public AudioSource sfxButtonOn;
    public AudioSource sfxButtonOff;

    public static SoundManager instance;

    public enum State{
        Play,
        Stop,
    }

    private void Awake()
    {
        if (!instance)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void MusicMenu(State state)
    {
        if(state == State.Play)
        {
            musicMenu.Play();
        }
        else
        {
            musicMenu.Stop();
        }
    }


    public void MusicLevel(State state)
    {
        if (state == State.Play)
        {
            musicLevel.Play();
        }
        else
        {
            musicLevel.Stop();
        }
    }


    public void SfxCubeRouge(State state)
    {
        if (state == State.Play)
        {
            sfxCubeRouge.Play();
        }
        else
        {
            sfxCubeRouge.Stop();
        }
    }


    public void SfxCubeBleu(State state)
    {
        if (state == State.Play)
        {
            sfxCubeBleu.Play();
        }
        else
        {
            sfxCubeBleu.Stop();
        }
    }

    public void SfxCubeBlanc(State state)
    {
        if (state == State.Play)
        {
            sfxCubeBlanc.Play();
        }
        else
        {
            sfxCubeBlanc.Stop();
        }
    }

    public void SfxCubeTemporel(State state)
    {
        if (state == State.Play)
        {
            sfxCubeTemporel.Play();
        }
        else
        {
            sfxCubeTemporel.Stop();
        }
    }

    public void SfxReset(State state)
    {
        if (state == State.Play)
        {
            sfxReset.Play();
        }
        else
        {
            sfxReset.Stop();
        }
    }

    public void SfxDoor(State state)
    {
        if (state == State.Play)
        {
            sfxDoor.Play();
        }
        else
        {
            sfxDoor.Stop();
        }
    }

    public void SfxButtonOn(State state)
    {
        if (state == State.Play)
        {
            sfxButtonOn.Play();
        }
        else
        {
            sfxButtonOn.Stop();
        }
    }

    public void SfxButtonOff(State state)
    {
        if (state == State.Play)
        {
            sfxButtonOff.Play();
        }
        else
        {
            sfxButtonOff.Stop();
        }
    }

}
