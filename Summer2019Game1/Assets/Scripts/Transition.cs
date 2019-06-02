using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public GameObject transitionCircle;
    public Animator transition;

    public IEnumerator TransitionToNextLevel() //Transition + goes to next scene in build.
    {
        transition.SetBool("MoveOut", false);
        transition.SetBool("MoveIn", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public IEnumerator TransitionFromPreviousLevel() //Transitions from the previous scene.
    {
        transition.SetBool("MoveIn", false);
        transition.SetBool("MoveOut", true);
        yield return new WaitForSeconds(1);
        transition.SetBool("MoveOut", false);
    }

    public IEnumerator TransitionToMainMenu() //Transition + goes to first scene in build (main menu)
    {
        transition.SetBool("MoveOut", false);
        transition.SetBool("MoveIn", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(0);
    }

    public IEnumerator TransitionToLevelRestart() //Transition + restarts scene
    {
        transition.SetBool("MoveOut", false);
        transition.SetBool("MoveIn", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public IEnumerator TransitionToQuit() //Transition + ends game.
    {
        transition.SetBool("MoveOut", false);
        transition.SetBool("MoveIn", true);
        yield return new WaitForSeconds(1);
        Application.Quit();
    }
}
