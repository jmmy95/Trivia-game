using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    
    public void PlayGame()
    {
        SceneManager.LoadScene("TriviaGamePlay");
    }
    
    public void QuitGame() 
    {
       #if UNITY_EDITOR
          EditorApplication.isPlaying = false;
       #else
        Application.Quit();
       #endif
    }

    // Placeholder method for the leaderboard button
    // Placeholder method for the leaderboard button
    public void LeaderboardButton()
    {

        Debug.Log("Leaderboard button pressed!");
        SceneManager.LoadScene("LoginScene");

        // Add functionality to display the leaderboard UI here when ready
    }
}

