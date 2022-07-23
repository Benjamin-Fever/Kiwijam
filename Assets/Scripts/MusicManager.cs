using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private bool musicIsOn;
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip bgSong;
    
    void Start()
    {
        if (musicIsOn)
        {
            musicSource.clip = bgSong;
            musicSource.Play();
        }
    }

}
