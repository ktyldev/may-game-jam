using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuControls : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }
}
