using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 120f;
    public TextMeshProUGUI timerText;

    private Color startColor = Color.white;
    private Color endColor = Color.red;
    private float totalTime;

    private void Start()
    {
        totalTime = timeRemaining;
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerDisplay();
        }
        else
        {
            timeRemaining = 0;
            timerText.text = "Time's Up!";

            //get the tmp text and make it an int
            int score = int.Parse(GameObject.Find("Score").GetComponent<TextMeshProUGUI>().text);
            PlayerPrefs.SetInt("tempscore", score);

            SceneManager.LoadScene("EndScene");
        }
        if (timeRemaining < 60 && timeRemaining > 0)
        {
            UpdateTextColor();
        }
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void UpdateTextColor()
    {
        float lerpValue = 1 - (timeRemaining / totalTime); // Goes from 0 to 1 over time
        timerText.color = Color.Lerp(startColor, endColor, lerpValue);
    }
}
