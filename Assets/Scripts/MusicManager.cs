using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private bool musicIsOn;
    [SerializeField] private AudioClip bgSong;
    private AudioSource musicSource;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.clip = bgSong;

        if (musicIsOn)
        {
            musicSource.Play();
        }
    }

}
