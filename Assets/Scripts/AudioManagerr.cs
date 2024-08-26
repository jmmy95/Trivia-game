using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerr : MonoBehaviour
{
    //Audio files script

    //Audio Source
    [SerializeField] AudioSource musicSource;

    //Audio Clip
    public AudioClip background;

    private static AudioManagerr instance;
    private void Awake()
      {
        if (instance == null)
        {
            instance = this;
            // prevent this gameobject from being destroyed when loading the new scene
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
        Destroy(gameObject);
        }
    }
    private void Start() 
     {
        if(musicSource != null && background != null) 
       {
            musicSource.clip = background;
            musicSource.Play();
        }

    }
}
