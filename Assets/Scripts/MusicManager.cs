using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] music;
    private AudioSource aSource;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
        SetMusicTrack(0);
    }

    public void SetMusicTrack(int ID)
    {
        AudioClip currentMusic = music[ID];

        if(currentMusic)
        {
            aSource.clip = currentMusic;
            aSource.loop = true;
            aSource.Play();
        }
    }
}
