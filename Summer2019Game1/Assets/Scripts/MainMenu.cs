using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Music");
    }

    public void PlayGame() //Goes to next scene
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame() //Quits game
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        Application.Quit();
    }

    public void MainMenuButton() //Goes back one scene 
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void OnMouseEnter()
    {
        {
            FindObjectOfType<AudioManager>().Play("Highlighted");
        }
    }

    public void OnMouseEnter2()
    {
        {
            FindObjectOfType<AudioManager>().Play("HighlightedLower");
        }
    }
}
