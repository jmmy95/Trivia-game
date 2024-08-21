using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   //Audio files script

   //Audio Source
   [SerializeField] AudioSource musicSource;

    //Audio Clip
   public AudioClip background;

   private void Start (){
    musicSource.clip = background;
    musicSource.Play();
   }
   
}
