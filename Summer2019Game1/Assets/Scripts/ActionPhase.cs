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

    private float currCountdownValue;

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
                if (dP.ally1MoveSelected == "War Cry") //If the move selected is War Cry...
                {
                    if (dP.ally1TargetSelected == dP.ally1Name) //If the target selected is ally1...
                    {
                        ally1STRbuff = 5;
                    }
                    else if (dP.ally1TargetSelected == dP.ally2Name) //If the target selected is ally2...
                    {
                        ally2STRbuff = 5;
                    }
                    else if (dP.ally1TargetSelected == dP.ally3Name) //If the target selected is ally3...
                    {
                        ally3STRbuff = 5;
                    }

                    dP.ally1MoveSelected = "";
                    dP.ally1TargetSelected = "";
                }

                else if (dP.ally1MoveSelected == "Bandage-Up") //If the move selected is Bandage-Up...
                {
                    if (dP.ally1TargetSelected == dP.ally1Name) //If the target selected is ally1...
                    {
                        dP.ally1Health += 6;
                        if (dP.ally1Health > dP.ally1MaxHealth)
                        {
                            dP.ally1Health = dP.ally1MaxHealth;
                        }
                    }
                    else if (dP.ally1TargetSelected == dP.ally2Name) //If the target selected is ally2...
                    {
                        dP.ally2Health += 6;
                        if (dP.ally2Health > dP.ally2MaxHealth)
                        {
                            dP.ally2Health = dP.ally2MaxHealth;
                        }
                    }
                    else if (dP.ally1TargetSelected == dP.ally3Name) //If the target selected is ally3...
                    {
                        dP.ally3Health += 6;
                        if (dP.ally3Health > dP.ally3MaxHealth)
                        {
                            dP.ally3Health = dP.ally3MaxHealth;
                        }
                    }

                    dP.ally1MoveSelected = "";
                    dP.ally1TargetSelected = "";
                }

                else if (dP.ally1MoveSelected == "Defend") //If the move selected is Defend...
                {
                    ally1DEFbuff += 5;
                    dP.ally1MoveSelected = "";
                    dP.ally1TargetSelected = "";
                }
            }

            //If HeroProtagonist is ally2...
            if (dP.ally2Name == "HeroProtagonist")
            {
                if (dP.ally2MoveSelected == "War Cry") //If the move selected is War Cry...
                {
                    if (dP.ally2TargetSelected == dP.ally1Name) //If the target selected is ally1...
                    {
                        ally1STRbuff = 5;
                    }
                    else if (dP.ally2TargetSelected == dP.ally2Name) //If the target selected is ally2...
                    {
                        ally2STRbuff = 5;
                    }
                    else if (dP.ally2TargetSelected == dP.ally3Name) //If the target selected is ally3...
                    {
                        ally3STRbuff = 5;
                    }

                    dP.ally2MoveSelected = "";
                    dP.ally2TargetSelected = "";
                }

                else if (dP.ally2MoveSelected == "Bandage-Up") //If the move selected is Bandage-Up...
                {
                    if (dP.ally2TargetSelected == dP.ally1Name) //If the target selected is ally1...
                    {
                        dP.ally1Health += 6;
                        if (dP.ally1Health > dP.ally1MaxHealth)
                        {
                            dP.ally1Health = dP.ally1MaxHealth;
                        }
                    }
                    else if (dP.ally2TargetSelected == dP.ally2Name) //If the target selected is ally2...
                    {
                        dP.ally2Health += 6;
                        if (dP.ally2Health > dP.ally2MaxHealth)
                        {
                            dP.ally2Health = dP.ally2MaxHealth;
                        }
                    }
                    else if (dP.ally2TargetSelected == dP.ally3Name) //If the target selected is ally3...
                    {
                        dP.ally3Health += 6;
                        if (dP.ally3Health > dP.ally3MaxHealth)
                        {
                            dP.ally3Health = dP.ally3MaxHealth;
                        }
                    }

                    dP.ally2MoveSelected = "";
                    dP.ally2TargetSelected = "";
                }

                else if (dP.ally2MoveSelected == "Defend") //If the move selected is Defend...
                {
                    ally2DEFbuff += 5;
                    dP.ally2MoveSelected = "";
                    dP.ally2TargetSelected = "";
                }
            }

            //If HeroProtagonist is ally3...
            if (dP.ally3Name == "HeroProtagonist")
            {
                if (dP.ally3MoveSelected == "War Cry") //If the move selected is War Cry...
                {
                    if (dP.ally3TargetSelected == dP.ally1Name) //If the target selected is ally1...
                    {
                        ally1STRbuff = 5;
                    }
                    else if (dP.ally3TargetSelected == dP.ally2Name) //If the target selected is ally2...
                    {
                        ally2STRbuff = 5;
                    }
                    else if (dP.ally3TargetSelected == dP.ally3Name) //If the target selected is ally3...
                    {
                        ally3STRbuff = 5;
                    }

                    dP.ally3MoveSelected = "";
                    dP.ally3TargetSelected = "";
                }

                else if (dP.ally3MoveSelected == "Bandage-Up") //If the move selected is Bandage-Up...
                {
                    if (dP.ally3TargetSelected == dP.ally1Name) //If the target selected is ally1...
                    {
                        dP.ally1Health += 6;
                        if (dP.ally1Health > dP.ally1MaxHealth)
                        {
                            dP.ally1Health = dP.ally1MaxHealth;
                        }
                    }
                    else if (dP.ally3TargetSelected == dP.ally2Name) //If the target selected is ally2...
                    {
                        dP.ally2Health += 6;
                        if (dP.ally2Health > dP.ally2MaxHealth)
                        {
                            dP.ally2Health = dP.ally2MaxHealth;
                        }
                    }
                    else if (dP.ally3TargetSelected == dP.ally3Name) //If the target selected is ally3...
                    {
                        dP.ally3Health += 6;
                        if (dP.ally3Health > dP.ally3MaxHealth)
                        {
                            dP.ally3Health = dP.ally3MaxHealth;
                        }
                    }

                    dP.ally3MoveSelected = "";
                    dP.ally3TargetSelected = "";
                }

                else if (dP.ally3MoveSelected == "Defend") //If the move selected is Defend...
                {
                    ally3DEFbuff += 5;
                    dP.ally3MoveSelected = "";
                    dP.ally3TargetSelected = "";
                }
            }

            ChangeCharacterTurnDefensivePhase();
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
                if (dP.ally1MoveSelected == "Sword Slash") //If the move selected is Sword Slash...
                {
                    if (dP.ally1TargetSelected == dP.enemy1Name) //If the target selected is enemy1...
                    {
                        dP.enemy1Health -= (10 + ally1STRbuff) - enemy1DEFbuff;
                    }
                    else if (dP.ally1TargetSelected == dP.enemy2Name) //If the target selected is enemy2...
                    {
                        dP.enemy2Health -= (10 + ally1STRbuff) - enemy2DEFbuff;
                    }
                    else if (dP.ally1TargetSelected == dP.enemy3Name) //If the target selected is enemy3...
                    {
                        dP.enemy3Health -= (10 + ally1STRbuff) - enemy3DEFbuff;
                    }
                }

                else if (dP.ally1MoveSelected == "Windmill") //If the move selected is Windmill...
                {
                    dP.enemy1Health -= (5 + ally1STRbuff) - enemy1DEFbuff;
                    dP.enemy2Health -= (5 + ally1STRbuff) - enemy2DEFbuff;
                    dP.enemy3Health -= (5 + ally1STRbuff) - enemy3DEFbuff;
                }

                dP.ally1MoveSelected = "";
                dP.ally1TargetSelected = "";
            }

            //If HeroProtagonist is ally2...
            else if (dP.ally2Name == "HeroProtagonist")
            {
                if (dP.ally2MoveSelected == "Sword Slash") //If the move selected is Sword Slash...
                {
                    if (dP.ally2TargetSelected == dP.enemy1Name) //If the target selected is enemy1...
                    {
                        dP.enemy1Health -= (10 + ally2STRbuff) - enemy1DEFbuff;
                    }
                    else if (dP.ally2TargetSelected == dP.enemy2Name) //If the target selected is enemy2...
                    {
                        dP.enemy2Health -= (10 + ally2STRbuff) - enemy2DEFbuff;
                    }
                    else if (dP.ally2TargetSelected == dP.enemy3Name) //If the target selected is enemy3...
                    {
                        dP.enemy3Health -= (10 + ally2STRbuff) - enemy3DEFbuff;
                    }
                }

                else if (dP.ally2MoveSelected == "Windmill") //If the move selected is Windmill...
                {
                    dP.enemy1Health -= (5 + ally2STRbuff) - enemy1DEFbuff;
                    dP.enemy2Health -= (5 + ally2STRbuff) - enemy2DEFbuff;
                    dP.enemy3Health -= (5 + ally2STRbuff) - enemy3DEFbuff;
                }

                dP.ally2MoveSelected = "";
                dP.ally2TargetSelected = "";
            }

            //If HeroProtagonist is ally3...
            else if (dP.ally3Name == "HeroProtagonist")
            {
                if (dP.ally3MoveSelected == "Sword Slash") //If the move selected is Sword Slash...
                {
                    if (dP.ally3TargetSelected == dP.enemy1Name) //If the target selected is enemy1...
                    {
                        dP.enemy1Health -= (10 + ally3STRbuff) - enemy1DEFbuff;
                    }
                    else if (dP.ally3TargetSelected == dP.enemy2Name) //If the target selected is enemy2...
                    {
                        dP.enemy2Health -= (10 + ally3STRbuff) - enemy2DEFbuff;
                    }
                    else if (dP.ally3TargetSelected == dP.enemy3Name) //If the target selected is enemy3...
                    {
                        dP.enemy3Health -= (10 + ally3STRbuff) - enemy3DEFbuff;
                    }
                }

                else if (dP.ally3MoveSelected == "Windmill") //If the move selected is Windmill...
                {
                    dP.enemy1Health -= (5 + ally3STRbuff) - enemy1DEFbuff;
                    dP.enemy2Health -= (5 + ally3STRbuff) - enemy2DEFbuff;
                    dP.enemy3Health -= (5 + ally3STRbuff) - enemy3DEFbuff;
                }

                dP.ally3MoveSelected = "";
                dP.ally3TargetSelected = "";
            }

            ChangeCharacterTurnOffensivePhase();
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
