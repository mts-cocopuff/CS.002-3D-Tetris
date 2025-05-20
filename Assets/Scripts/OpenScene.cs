using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//take speed variable from Gravity.cs and put it in here


public class OpenScene : MonoBehaviour
{

    public NameSelect nameScript;
    public GameObject obj;

    public void NextScene()
    {
        SceneManager.LoadScene("XRinCurrentModel");
    }

    public void Easy()
    {
        obj.GetComponent<Gravity>().speed = 3f;
        PlayerPrefs.SetInt("speed", 3);
        SceneManager.LoadScene("XRinCurrentModel");
    }

    public void Medium()
    {
        obj.GetComponent<Gravity>().speed = 5f;
        PlayerPrefs.SetInt("speed", 5);
        SceneManager.LoadScene("XRinCurrentModel");
    }

    public void Hard()
    {
        obj.GetComponent<Gravity>().speed = 7f;
        PlayerPrefs.SetInt("speed", 7);
        SceneManager.LoadScene("XRinCurrentModel");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("StartXRMenu");
    }

    public void GoToOptions()
    {
        SceneManager.LoadScene("OptionsMenu");
    }
    
    public void GoToLeaderboard()
    {
        string playerName = ((char)nameScript.N1).ToString() +
        ((char)nameScript.N2).ToString() + 
        ((char)nameScript.N3).ToString();

        PlayerPrefs.SetString("PlayerName", playerName);
        
        SceneManager.LoadScene("XREndScene");
    }
    
}
