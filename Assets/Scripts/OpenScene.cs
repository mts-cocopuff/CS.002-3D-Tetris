using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//take speed variable from Gravity.cs and put it in here


public class OpenScene : MonoBehaviour
{

    public GameObject obj;
    
    public void NextScene()
    {
        SceneManager.LoadScene("XRinCurrentModel");
    }

    public void Easy()
    {
        obj.GetComponent<Gravity>().speed = 3f;
        SceneManager.LoadScene("XRinCurrentModel");
    }

    public void Medium()
    {
        obj.GetComponent<Gravity>().speed = 5f;
        SceneManager.LoadScene("XRinCurrentModel");
    }

    public void Hard()
    {
        obj.GetComponent<Gravity>().speed = 7f;
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
    
}
