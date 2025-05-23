using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToOptions : MonoBehaviour
{
    public void GoToLeaderboard()
    {
        PlayerPrefs.SetInt("tempscore", 0);
        PlayerPrefs.SetString("PlayerName", "");
        SceneManager.LoadScene("XREndScene");
    }


}
