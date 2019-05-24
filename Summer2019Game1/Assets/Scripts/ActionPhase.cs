using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhase : MonoBehaviour
{
    private DecisionPhase dP;
    private string characterTurn;

    void Awake()
    {
        dP = GameObject.FindWithTag("CombatControl").GetComponent<DecisionPhase>();
    }

    // Start is called before the first frame update
    void Start()
    {
        characterTurn = dP.ally1Name;
    }

    // Update is called once per frame
    void Update()
    {
        if (dP.actionPhase == true) //if the Action Phase is active, call the character functions.
        {
            HeroProtagonist();
            //GlassCannon();
            //SupportMain();
            //Slime();
        }
    }

    void HeroProtagonist() //Called when the characterTurn == "HeroProtagonist"; plays his actions.
    {
        if (characterTurn == "HeroProtagonist")
        {
            //Play actions
            ChangeCharacterTurn();
        }
    }

    void ChangeCharacterTurn() //Called when it's needed to change characterTurn. After enemy3's turn is finished it'll  turn off ActionPhase and set up variables for DecisionPhase.
    {
        if (characterTurn == dP.ally1Name)
        {
            characterTurn = dP.ally2Name;
        }
        else if (characterTurn == dP.ally2Name)
        {
            characterTurn = dP.ally3Name;
        }
        else if (characterTurn == dP.ally3Name)
        {
            characterTurn = dP.enemy1Name;
        }
        else if (characterTurn == dP.enemy1Name)
        {
            characterTurn = dP.enemy2Name;
        }
        else if (characterTurn == dP.enemy2Name)
        {
            characterTurn = dP.enemy3Name;
        }
        else if (characterTurn == dP.enemy3Name)
        {
            characterTurn = "";
            dP.actionPhase = false;

            dP.ally1MoveSelected = ""; dP.ally2MoveSelected = ""; dP.ally3MoveSelected = ""; dP.enemy1MoveSelected = ""; dP.enemy2MoveSelected = ""; dP.enemy3MoveSelected = "";
            dP.ally1TargetSelected = ""; dP.ally2TargetSelected = ""; dP.ally3TargetSelected = ""; dP.enemy1TargetSelected = ""; dP.enemy2TargetSelected = ""; dP.enemy3TargetSelected = "";

            dP.ally1Move1.SetActive(true);
            dP.ally1Move2.SetActive(true);
            dP.ally1Move3.SetActive(true);
            dP.ally1Move4.SetActive(true);
            dP.defendMove.SetActive(true);

            dP.Move1Button.SetActive(true);
            dP.Move2Button.SetActive(true);
            dP.Move3Button.SetActive(true);
            dP.Move4Button.SetActive(true);
            dP.DefendButton.SetActive(true);

            dP.characterTurn = dP.ally1Name;
            dP.charactersTurnText.text = characterTurn + "'s Turn";
        }
    }
}
