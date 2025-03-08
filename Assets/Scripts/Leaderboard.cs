using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour
{


    void Start(){
        int endScore = PlayerPrefs.GetInt("tempscore", 0);
        AddNewScore(endScore);
        List<int> topScores = LoadHighScores();
        foreach (int score in topScores)
        {
            Debug.Log("High Score: " + score);
        }
    }
    void SaveHighScores(List<int> highScores)
    {
        // Ensure the list has at least 10 scores (pad with zeros if necessary)
        while (highScores.Count < 10)
        {
            highScores.Add(0);
        }

        // Save each score to PlayerPrefs
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("HighScore" + (i + 1), highScores[i]);
        }

        PlayerPrefs.Save();  // Ensure data is saved immediately
    }

    List<int> LoadHighScores()
    {
        List<int> highScores = new List<int>();

        // Load the scores from PlayerPrefs
        for (int i = 0; i < 10; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + (i + 1), 0);  // Default to 0 if not found
            highScores.Add(score);
        }

        return highScores;
    }

    void AddNewScore(int newScore)
    {
        List<int> highScores = LoadHighScores();

        // Add the new score to the list
        highScores.Add(newScore);

        // Sort the list in descending order (highest score first)
        highScores.Sort((a, b) => b.CompareTo(a));

        // Trim the list to the top 10 scores
        if (highScores.Count > 10)
        {
            highScores.RemoveAt(10);  // Remove the lowest score if there are more than 10
        }

        // Save the updated list of high scores
        SaveHighScores(highScores);
    }

}
