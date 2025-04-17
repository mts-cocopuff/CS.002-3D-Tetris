using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//take speed variable from Gravity.cs and put it in here


public class OpenScene : MonoBehaviour
{

    private Gravity gravityScript;

    void Start(){
        gravityScript = GameObject.Find("3DPiece").GetComponent<Gravity>();
    }
    
    public void NextScene()
    {
        SceneManager.LoadScene("XRinCurrentModel");
    }

    public void Easy()
    {
        gravityScript.speed = 3f;
        SceneManager.LoadScene("XRinCurrentModel");
    }

    public void Medium()
    {
        gravityScript.speed = 5f;
        SceneManager.LoadScene("XRinCurrentModel");
    }

    public void Hard()
    {
        gravityScript.speed = 7f;
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
