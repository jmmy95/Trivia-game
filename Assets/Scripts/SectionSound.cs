// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SectionSound : MonoBehaviour
// {
//     public AudioSource sectionClick; //section button click sound

//     public AudioSource quitClick;

//     public AudioSource leaderboardClick;
//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {

//     }

//     public void playSectionClickSoundEffect()
//     {
//         sectionClick.Play();
//     }


//     public void playThisQuitEffect(){
//         quitClick.Play();
//     }

//     public void playThisLeaderboardEffect(){
//         leaderboardClick.Play();
//     }

// }



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionSound : MonoBehaviour
{
    public AudioSource sectionClick; // Section button click sound
    // public AudioSource quitClick;
    // public AudioSource leaderboardClick;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySectionClickSoundEffect()
    {
        if (sectionClick != null)
        {
            sectionClick.Play();
        }
        else
        {
            Debug.LogWarning("Section click sound not assigned!");
        }
    }

    // public void PlayQuitEffect()
    // {
    //     if (quitClick != null)
    //     {
    //         quitClick.Play();
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Quit click sound not assigned!");
    //     }
    // }

    // public void PlayLeaderboardEffect()
    // {
    //     if (leaderboardClick != null)
    //     {
    //         leaderboardClick.Play();
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Leaderboard click sound not assigned!");
    //     }
    // }
}
