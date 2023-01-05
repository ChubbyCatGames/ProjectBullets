using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClip[] audios;
    private AudioSource controlAudio;

    [SerializeField] private AudioSource musicMenu, musicGame;



    private void Awake()
    {
        controlAudio = GetComponent<AudioSource>();
    }

    public void SeleccionAudio (int indice, float volume)
    {
        controlAudio.PlayOneShot(audios[indice], volume);
    }

    public void PlayMenuMusic()
    {
        musicGame.Stop();
        musicMenu.Play();
    }

    public void PlayGameMusic()
    {
        musicMenu.Stop();
        musicGame.Play();
    }
}
