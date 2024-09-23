using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void ExitButton()
    {
        Application.Quit();
        Debug.Log("Game Closed");
    }



}
