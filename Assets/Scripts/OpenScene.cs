using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("XRSpawningPieces");
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
