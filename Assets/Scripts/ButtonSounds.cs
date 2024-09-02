using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSounds : MonoBehaviour
{

    public AudioSource buttonClick;

    public AudioSource leaderboardClick;

    public AudioSource quitClick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playThisSoundEffect() {
        buttonClick.Play();
    }

    public void leaderboardSoundEffect ()
    {
        leaderboardClick.Play();
    }
    public void quitSoundEffect ()
    {
        quitClick.Play();
    }

    
}

