using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Leaderboard : MonoBehaviour
{

    //add tmp prefabs to show high scores on
    public GameObject scorePrefab;


    public class ScoreEntry
    {
        public int score;
        public string name;

        public ScoreEntry(int score, string name)
        {
            this.score = score;
            this.name = name;
        }
    }


    void Start(){
        int endScore = PlayerPrefs.GetInt("tempscore", 0);
        string playerName = PlayerPrefs.GetString("PlayerName", "");
        Debug.Log("Player Name: " + playerName);
        AddNewScore(new ScoreEntry(endScore, playerName));
        List<ScoreEntry> topScores = LoadHighScores();
        DisplayHighScores();
    }
    void SaveHighScores(List<ScoreEntry> highScores)
    {
        // Ensure the list has at least 10 scores (pad with zeros if necessary)
        while (highScores.Count < 10)
        {
            highScores.Add(new ScoreEntry(0, ""));  // Add empty entries
        }

        // Save each score to PlayerPrefs
        for (int i = 0; i < highScores.Count; i++)
        {
            PlayerPrefs.SetInt("HighScore" + (i + 1), highScores[i].score);
            PlayerPrefs.SetString("PlayerName" + (i + 1), highScores[i].name);
        }

        PlayerPrefs.Save();  // Ensure data is saved immediately
    }

    List<ScoreEntry> LoadHighScores()
    {
        List<ScoreEntry> highScores = new List<ScoreEntry>();

        // Load the scores from PlayerPrefs
        for (int i = 0; i < 10; i++)
        {
            int score = PlayerPrefs.GetInt("HighScore" + (i + 1), 0);  // Default to 0 if not found
            string name = PlayerPrefs.GetString("PlayerName" + (i + 1), "");  // Default to empty string if not found
            highScores.Add(new ScoreEntry(score, name));
        }

        return highScores;
    }

    void AddNewScore(ScoreEntry newScore)
    {
        List<ScoreEntry> highScores = LoadHighScores();

        // Add the new score to the list
        highScores.Add(newScore);

        // Sort the list in descending order (highest score first)
        highScores.Sort((a, b) => b.score.CompareTo(a.score));
        // Trim the list to the top 10 scores
        if (highScores.Count > 10)
        {
            highScores.RemoveAt(10);  // Remove the lowest score if there are more than 10
        }

        // Save the updated list of high scores
        SaveHighScores(highScores);
    }

    //display high scores on textmeshpro prefabs
    void DisplayHighScores()
    {
        List<ScoreEntry> highScores = LoadHighScores();
        for (int i = 0; i < highScores.Count; i++)
        {
            // Instantiate a new TMP prefab for each score
            // set text position to be 300, 0, 0
            scorePrefab.GetComponent<TextMeshProUGUI>().fontSize = 50;
            scorePrefab = Instantiate(scorePrefab, transform);
            RectTransform rt = scorePrefab.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(700, 300 -(i * 70)); // Adjust the Y position based on the index
            //set text to be 'score: ' + highScores[i].score + ' name: ' + highScores[i].name
            scorePrefab.GetComponent<TextMeshProUGUI>().text = (i + 1) + ". " + highScores[i].score + " -- " + highScores[i].name;
        }
    }


}
