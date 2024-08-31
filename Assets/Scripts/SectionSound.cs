using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionSound : MonoBehaviour
{
    public AudioSource sectionClick; //section button click sound

    public AudioSource quitClick;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playSectionClickSoundEffect()
    {
        sectionClick.Play();
    }


    public void playThisQuitEffect(){
        quitClick.Play();
    }

}
