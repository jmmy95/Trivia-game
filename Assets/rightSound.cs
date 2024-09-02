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

// using UnityEngine;

// public class rightSound : MonoBehaviour
// {
//     public AudioClip correctClip;
//     public AudioClip incorrectClip;

//     private AudioSource audioSource;

//     void Start()
//     {
//         audioSource = GetComponent<AudioSource>();
//     }

//     private void OnEnable()
//     {
//         if (audioSource != null)
//         {
//             // Determine which clip to play based on GameObject's name or tag
//             if (gameObject.name == "correct" && correctClip != null)
//             {
//                 audioSource.clip = correctClip;
//             }
//             else if (gameObject.name == "INCORRECT" && incorrectClip != null)
//             {
//                 audioSource.clip = incorrectClip;
//             }

//             audioSource.Play();
//         }
//     }
// }

using UnityEngine;

public class rightSound : MonoBehaviour
{
    public AudioClip correctClip;
    public AudioClip incorrectClip;

    private AudioSource audioSource;

    void Awake()
    {
        // Attempt to find the AudioSource component
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing on GameObject: " + gameObject.name);
        }
        else
        {
            Debug.Log("AudioSource found on: " + gameObject.name);
        }
    }

    private void OnEnable()
    {
        if (audioSource != null)
        {
            Debug.Log("OnEnable called on GameObject: " + gameObject.name);

            // Determine which clip to play based on GameObject's name
            if (gameObject.name == "correct" && correctClip != null)
            {
                audioSource.clip = correctClip;
                Debug.Log("Correct sound assigned for " + gameObject.name);
            }
            else if (gameObject.name == "INCORRECT" && incorrectClip != null)
            {
                audioSource.clip = incorrectClip;
                Debug.Log("Incorrect sound assigned for " + gameObject.name);
            }

            // Play the assigned audio clip when the GameObject is enabled
            if (audioSource.clip != null)
            {
                Debug.Log("Playing clip: " + audioSource.clip.name + " on GameObject: " + gameObject.name);
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("Audio clip not assigned or found for GameObject: " + gameObject.name);
            }
        }
        else
        {
            Debug.LogError("AudioSource component not found on GameObject: " + gameObject.name);
        }
    }
}


// using UnityEngine;

// public class rightSound : MonoBehaviour
// {
//     public AudioClip correctClip;
//     public AudioClip incorrectClip;

//     private AudioSource audioSource;

//     // Initialize AudioSource early to ensure it's set before any other methods
//     void Awake()
//     {
//         audioSource = GetComponent<AudioSource>();

//         if (audioSource == null)
//         {
//             Debug.LogError("AudioSource component is missing on GameObject: " + gameObject.name);
//         }
//         else
//         {
//             Debug.Log("AudioSource found on: " + gameObject.name);
//         }
//     }

//     private void OnEnable()
//     {
//         if (audioSource != null)
//         {
//             Debug.Log("OnEnable called on GameObject: " + gameObject.name);

//             // Determine which clip to play based on GameObject's name
//             if (gameObject.name == "correct" && correctClip != null)
//             {
//                 audioSource.clip = correctClip;
//                 Debug.Log("Correct sound assigned for " + gameObject.name);
//             }
//             else if (gameObject.name == "INCORRECT" && incorrectClip != null)
//             {
//                 audioSource.clip = incorrectClip;
//                 Debug.Log("Incorrect sound assigned for " + gameObject.name);
//             }

//             // Ensure the AudioSource is stopped before playing the clip again
//             if (audioSource.clip != null)
//             {
//                 audioSource.Stop(); // Reset the AudioSource to ensure it can play the sound again
//                 Debug.Log("Playing clip: " + audioSource.clip.name + " on GameObject: " + gameObject.name);
//                 audioSource.Play();
//             }
//             else
//             {
//                 Debug.LogWarning("Audio clip not assigned or found for GameObject: " + gameObject.name);
//             }
//         }
//         else
//         {
//             Debug.LogError("AudioSource component not found on GameObject: " + gameObject.name);
//         }
//     }
// }
