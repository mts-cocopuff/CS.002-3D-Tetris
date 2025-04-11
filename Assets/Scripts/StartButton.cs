using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartButton : MonoBehaviour
{
    public TextMeshProUGUI playerNameText;

    // Update is called once per frame
    public void LoadGame()
    {
        // Load the game scene
        if (playerNameText.text == "Enter 3 Letter Name​")
        {
            PlayerPrefs.SetString("PlayerName", "");
        }
        else
        {
            PlayerPrefs.SetString("PlayerName", playerNameText.text);
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("CurrentVersion");
    }
}
