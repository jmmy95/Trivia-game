// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class rightSound : MonoBehaviour
// {

//     private AudioSource correctSound;

//     private AudioSource incorrectSound;
//     // Start is called before the first frame update
//     void Start()
//     {
//         correctSound = GetComponent<AudioSource>();
//         incorrectSound = GetComponent<AudioSource>();
//     }

//       private void OnEnable()
//     {
//         if (correctSound != null)
//         {
//             correctSound.Play();
//         }else{
//             incorrectSound.Play();
//         }
//     }



// }

using UnityEngine;

public class rightSound : MonoBehaviour
{
    public AudioClip correctClip;
    public AudioClip incorrectClip;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        if (audioSource != null)
        {
            // Determine which clip to play based on GameObject's name or tag
            if (gameObject.name == "Right" && correctClip != null)
            {
                audioSource.clip = correctClip;
            }
            else if (gameObject.name == "Wrong" && incorrectClip != null)
            {
                audioSource.clip = incorrectClip;
            }

            audioSource.Play();
        }
    }
}

