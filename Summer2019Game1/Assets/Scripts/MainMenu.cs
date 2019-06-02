using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private Transition transition;

    void Awake()
    {
        transition = GameObject.FindWithTag("MainCamera").GetComponent<Transition>();
    }

    void Start()
    {
        StartCoroutine(transition.TransitionFromPreviousLevel());
        FindObjectOfType<AudioManager>().Play("Music");
    }

    public void PlayGame() //Goes to next scene
    {
        StartCoroutine(transition.TransitionToNextLevel());
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }

    public void QuitGame() //Quits game
    {
        StartCoroutine(transition.TransitionToQuit());
        FindObjectOfType<AudioManager>().Play("ButtonClick");     
    }

    public void MainMenuButton() //Goes back one scene 
    {
        StartCoroutine(transition.TransitionToMainMenu());
        FindObjectOfType<AudioManager>().Play("ButtonClick");
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
