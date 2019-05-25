using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPhase : MonoBehaviour
{
    private DecisionPhase dP;
    private string characterTurn;

    private int ally1STRbuff = 0;
    private int ally2STRbuff = 0;
    private int ally3STRbuff = 0;
    private int enemy1STRbuff = 0;
    private int enemy2STRbuff = 0;
    private int enemy3STRbuff = 0;

    private int ally1DEFbuff = 0;
    private int ally2DEFbuff = 0;
    private int ally3DEFbuff = 0;
    private int enemy1DEFbuff = 0;
    private int enemy2DEFbuff = 0;
    private int enemy3DEFbuff = 0;

    private bool defensivePhase = true;

    private int accuracy;

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
            if (defensivePhase == true)
            {
                HeroProtagonistDefensive();
                //GlassCannonDefensive();
                //SupportMainDefensive();
                //SlimeDefensive();
            }
            else
            {
                HeroProtagonistOffensive();
                //GlassCannonOffensive();
                //SupportMainOffensive();
                //SlimeOffensive();
            }

            /*if (Input.GetKeyDown("space"))
            {
                defensivePhase = false;
                characterTurn = "HeroProtagonist";
            }*/
        }
    }

    //Called when the characterTurn == "HeroProtagonist" and the move chosen was a defensive-type move.
    void HeroProtagonistDefensive() 
    {
        if (characterTurn == "HeroProtagonist")
        {
            //If HeroProtagonist is ally1...
            if (dP.ally1Name == "HeroProtagonist")
            {
                HeroProtagonistDefensiveAllyBranching(dP.ally1MoveSelected, dP.ally1TargetSelected);

                if (dP.ally1MoveSelected == "Defend")
                {
                    {
                        ally1DEFbuff += 5;
                    }
                }
                if (dP.ally1MoveSelected == "War Cry" || dP.ally1MoveSelected == "Bandage-Up" || dP.ally1MoveSelected == "Defend")
                {
                    dP.ally1MoveSelected = "";
                    dP.ally1TargetSelected = "";
                }
            }

            //If HeroProtagonist is ally2...
            if (dP.ally2Name == "HeroProtagonist")
            {
                HeroProtagonistDefensiveAllyBranching(dP.ally2MoveSelected, dP.ally2TargetSelected);

                if (dP.ally2MoveSelected == "Defend")
                {
                    {
                        ally2DEFbuff += 5;
                    }
                }
                if (dP.ally2MoveSelected == "War Cry" || dP.ally2MoveSelected == "Bandage-Up" || dP.ally2MoveSelected == "Defend")
                {
                    dP.ally2MoveSelected = "";
                    dP.ally2TargetSelected = "";
                }
            }

            //If HeroProtagonist is ally3...
            if (dP.ally3Name == "HeroProtagonist")
            {
                HeroProtagonistDefensiveAllyBranching(dP.ally3MoveSelected, dP.ally3TargetSelected);

                if (dP.ally3MoveSelected == "Defend")
                {
                    {
                        ally3DEFbuff += 5;
                    }
                }
                if (dP.ally3MoveSelected == "War Cry" || dP.ally3MoveSelected == "Bandage-Up" || dP.ally3MoveSelected == "Defend")
                {
                    dP.ally3MoveSelected = "";
                    dP.ally3TargetSelected = "";
                }
            }

            ChangeCharacterTurnDefensivePhase(); //If the characterTurn was "HeroProtagonist", call the function.
        }
    }

    //Called when the characterTurn == "HeroProtagonist" and the move chosen was an offensive-type move.
    void HeroProtagonistOffensive() 
    {
        if (characterTurn == "HeroProtagonist")
        {
            //If HeroProtagonist is ally1...
            if (dP.ally1Name == "HeroProtagonist")
            {
                HeroProtagonistOffensiveAllyBranching(dP.ally1MoveSelected, dP.ally1TargetSelected, ally1STRbuff);
                dP.ally1MoveSelected = "";
                dP.ally1TargetSelected = "";
            }

            //If HeroProtagonist is ally2...
            else if (dP.ally2Name == "HeroProtagonist")
            {
                HeroProtagonistOffensiveAllyBranching(dP.ally2MoveSelected, dP.ally2TargetSelected, ally2STRbuff);
                dP.ally2MoveSelected = "";
                dP.ally2TargetSelected = "";
            }

            //If HeroProtagonist is ally3...
            else if (dP.ally3Name == "HeroProtagonist")
            {
                HeroProtagonistOffensiveAllyBranching(dP.ally3MoveSelected, dP.ally3TargetSelected, ally3STRbuff);
                dP.ally3MoveSelected = "";
                dP.ally3TargetSelected = "";
            }
            ChangeCharacterTurnOffensivePhase(); //If the characterTurn was "HeroProtagonist", call the function.
        }
    }

    void HeroProtagonistOffensiveAllyBranching(string MoveSelected, string TargetSelected, int STRbuff) //Used for ally branching in the HeroProtagonistOffensive function.
    {
        if (MoveSelected == "Sword Slash") //If the move selected is Sword Slash...
        {
            accuracy = Random.Range(1, 101);

            if (TargetSelected == dP.enemy1Name && accuracy <= 80) //If the target selected is enemy1 and the accuracy is 80 or below...
            {
                dP.enemy1Health -= (10 + STRbuff) - enemy1DEFbuff;
            }
            else if (TargetSelected == dP.enemy2Name && accuracy <= 80) //If the target selected is enemy2 and the accuracy is 80 or below...
            {
                dP.enemy2Health -= (10 + STRbuff) - enemy2DEFbuff;
            }
            else if (TargetSelected == dP.enemy3Name && accuracy <= 80) //If the target selected is enemy3 and the accuracy is 80 or below...
            {
                dP.enemy3Health -= (10 + STRbuff) - enemy3DEFbuff;
            }
            else if (accuracy > 80) //Else if the accuracy is above 80, miss the target.
            {
                //Missed
            }
        }

        else if (MoveSelected == "Windmill") //If the move selected is Windmill...
        {
            accuracy = Random.Range(1, 101);
            if (accuracy <= 80)
            {
                dP.enemy1Health -= (5 + STRbuff) - enemy1DEFbuff;
            }
            else if (accuracy > 80)
            {
                //Missed
            }

            accuracy = Random.Range(1, 101);
            if (accuracy <= 80)
            {
                dP.enemy2Health -= (5 + STRbuff) - enemy2DEFbuff;
            }
            else if (accuracy > 80)
            {
                //Missed
            }

            accuracy = Random.Range(1, 101);
            if (accuracy <= 80)
            {
                dP.enemy3Health -= (5 + STRbuff) - enemy3DEFbuff;
            }
            else if (accuracy > 80)
            {
                //Missed
            }
        }
    }

    void HeroProtagonistDefensiveAllyBranching(string MoveSelected, string TargetSelected) //Used for ally branching in the HeroProtagonistDefensive function.
    {
        if (MoveSelected == "War Cry") //If the move selected is War Cry...
        {
            if (TargetSelected == dP.ally1Name) //If the target selected is ally1...
            {
                ally1STRbuff = 5;
            }
            else if (TargetSelected == dP.ally2Name) //If the target selected is ally2...
            {
                ally2STRbuff = 5;
            }
            else if (TargetSelected == dP.ally3Name) //If the target selected is ally3...
            {
                ally3STRbuff = 5;
            }
        }
        else if (MoveSelected == "Bandage-Up") //If the move selected is Bandage-Up...
        {
            if (TargetSelected == dP.ally1Name) //If the target selected is ally1...
            {
                dP.ally1Health += 6;
                if (dP.ally1Health > dP.ally1MaxHealth)
                {
                    dP.ally1Health = dP.ally1MaxHealth;
                }
            }
            else if (TargetSelected == dP.ally2Name) //If the target selected is ally2...
            {
                dP.ally2Health += 6;
                if (dP.ally2Health > dP.ally2MaxHealth)
                {
                    dP.ally2Health = dP.ally2MaxHealth;
                }
            }
            else if (TargetSelected == dP.ally3Name) //If the target selected is ally3...
            {
                dP.ally3Health += 6;
                if (dP.ally3Health > dP.ally3MaxHealth)
                {
                    dP.ally3Health = dP.ally3MaxHealth;
                }
            }
        }
    }

    void ChangeCharacterTurnDefensivePhase() //Called when it's needed to change characterTurn during the DefensivePhase;  after enemy3's defensive phase turn is over set the defensivePhase bool to false.
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
            defensivePhase = false;
            characterTurn = dP.ally1Name;
        }
    }

    void ChangeCharacterTurnOffensivePhase() //Called when it's needed to change characterTurn during the OffensivePhase. After enemy3's turn is finished it'll turn off ActionPhase and set up variables for DecisionPhase.
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

            //dP.ally1MoveSelected = ""; dP.ally2MoveSelected = ""; dP.ally3MoveSelected = ""; dP.enemy1MoveSelected = ""; dP.enemy2MoveSelected = ""; dP.enemy3MoveSelected = "";
            //dP.ally1TargetSelected = ""; dP.ally2TargetSelected = ""; dP.ally3TargetSelected = ""; dP.enemy1TargetSelected = ""; dP.enemy2TargetSelected = ""; dP.enemy3TargetSelected = "";

            ally1STRbuff = 0; ally2STRbuff = 0; ally3STRbuff = 0; enemy1STRbuff = 0; enemy2STRbuff = 0; enemy3STRbuff = 0;
            ally1DEFbuff = 0; ally2DEFbuff = 0; ally3DEFbuff = 0; enemy1DEFbuff = 0; enemy2DEFbuff = 0; enemy3DEFbuff = 0;

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
