using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ActionPhase : MonoBehaviour
{
    private DecisionPhase dP;
    public string characterTurn;

    [Header("Text Objects")]
    public TextMeshProUGUI ally1HealthLostText;
    public TextMeshProUGUI ally1MissText;
    public TextMeshProUGUI ally1StatusEffectText;
    public TextMeshProUGUI ally2HealthLostText;
    public TextMeshProUGUI ally2MissText;
    public TextMeshProUGUI ally2StatusEffectText;
    public TextMeshProUGUI ally3HealthLostText;
    public TextMeshProUGUI ally3MissText;
    public TextMeshProUGUI ally3StatusEffectText;
    public TextMeshProUGUI enemy1HealthLostText;
    public TextMeshProUGUI enemy1MissText;
    public TextMeshProUGUI enemy1StatusEffectText;
    public TextMeshProUGUI enemy2HealthLostText;
    public TextMeshProUGUI enemy2MissText;
    public TextMeshProUGUI enemy2StatusEffectText;
    public TextMeshProUGUI enemy3HealthLostText;
    public TextMeshProUGUI enemy3MissText;
    public TextMeshProUGUI enemy3StatusEffectText;

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

    public bool defensivePhase = true;

    private int accuracy;

    private bool ally1HasSmokeBomb = false;
    private bool ally2HasSmokeBomb = false;
    private bool ally3HasSmokeBomb = false;

    private int bleedChance;
    private int ally1IsBleeding = 0;
    private int ally2IsBleeding = 0;
    private int ally3IsBleeding = 0;
    private int enemy1IsBleeding = 0;
    private int enemy2IsBleeding = 0;
    private int enemy3IsBleeding = 0;
    private bool ally1HasBled = false;
    private bool ally2HasBled = false;
    private bool ally3HasBled = false;
    private bool enemy1HasBled = false;
    private bool enemy2HasBled = false;
    private bool enemy3HasBled = false;

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
                GlassCannonDefensive();
                SupportMainDefensive();
                SlimeDefensive();
            }
            else
            {
                Bleed();
                HeroProtagonistOffensive();
                GlassCannonOffensive();
                SupportMainOffensive();
                SlimeOffensive();
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

    void HeroProtagonistOffensiveAllyBranching(string MoveSelected, string TargetSelected, int STRbuff) //Used for ally branching in the HeroProtagonistOffensive function.
    {
        if (MoveSelected == "Sword Slash") //If the move selected is Sword Slash...
        {
            accuracy = Random.Range(1, 101);

            if (TargetSelected == dP.enemy1Name && accuracy <= 80) //If the target selected is enemy1 and the accuracy is 80 or below...
            {
                dP.enemy1Health -= (10 + STRbuff) - enemy1DEFbuff;
                StartCoroutine(ShowDamageDealt(enemy1HealthLostText, ((10 + STRbuff) - enemy1DEFbuff)));
            }
            else if (TargetSelected == dP.enemy1Name && accuracy > 80) //If the target selected is enemy1 but the attack misses...
            {
                StartCoroutine(ShowMiss(enemy1MissText));
            }
            else if (TargetSelected == dP.enemy2Name && accuracy <= 80) //If the target selected is enemy2 and the accuracy is 80 or below...
            {
                dP.enemy2Health -= (10 + STRbuff) - enemy2DEFbuff;
                StartCoroutine(ShowDamageDealt(enemy2HealthLostText, ((10 + STRbuff) - enemy2DEFbuff)));
            }
            else if (TargetSelected == dP.enemy2Name && accuracy > 80) //If the target selected is enemy2 but the attack misses...
            {
                StartCoroutine(ShowMiss(enemy2MissText));
            }
            else if (TargetSelected == dP.enemy3Name && accuracy <= 80) //If the target selected is enemy3 and the accuracy is 80 or below...
            {
                dP.enemy3Health -= (10 + STRbuff) - enemy3DEFbuff;
                StartCoroutine(ShowDamageDealt(enemy3HealthLostText, ((10 + STRbuff) - enemy3DEFbuff)));
            }
            else if (TargetSelected == dP.enemy3Name && accuracy > 80) //If the target selected is enemy3 but the attack misses...
            {
                StartCoroutine(ShowMiss(enemy3MissText));
            }
        }

        else if (MoveSelected == "Windmill") //If the move selected is Windmill...
        {
            accuracy = Random.Range(1, 101);
            if (accuracy <= 80)
            {
                dP.enemy1Health -= (5 + STRbuff) - enemy1DEFbuff;
                StartCoroutine(ShowDamageDealt(enemy1HealthLostText, ((5 + STRbuff) - enemy1DEFbuff)));
            }
            else if (accuracy > 80)
            {
                StartCoroutine(ShowMiss(enemy1MissText));
            }

            accuracy = Random.Range(1, 101);
            if (accuracy <= 80)
            {
                dP.enemy2Health -= (5 + STRbuff) - enemy2DEFbuff;
                StartCoroutine(ShowDamageDealt(enemy2HealthLostText, ((5 + STRbuff) - enemy2DEFbuff)));
            }
            else if (accuracy > 80)
            {
                StartCoroutine(ShowMiss(enemy2MissText));
            }

            accuracy = Random.Range(1, 101);
            if (accuracy <= 80)
            {
                dP.enemy3Health -= (5 + STRbuff) - enemy3DEFbuff;
                StartCoroutine(ShowDamageDealt(enemy3HealthLostText, ((5 + STRbuff) - enemy3DEFbuff)));
            }
            else if (accuracy > 80)
            {
                StartCoroutine(ShowMiss(enemy3MissText));
            }
        }
    }

    //Called when the characterTurn == "GlassCannon" and the move chosen was a defensive-type move.
    void GlassCannonDefensive()
    {
        if (characterTurn == "GlassCannon")
        {
            //If GlassCannon is ally1...
            if (dP.ally1Name == "GlassCannon")
            {
                GlassCannonDefensiveAllyBranching(dP.ally1MoveSelected, dP.ally1TargetSelected);

                if (dP.ally1MoveSelected == "Defend") //If the move selected is Defend...
                {
                    ally1DEFbuff += 5;
                }
                if (dP.ally1MoveSelected == "Smoke Bomb" || dP.ally1MoveSelected == "Defend")
                {
                    dP.ally1MoveSelected = "";
                    dP.ally1TargetSelected = "";
                }
            }


            //If GlassCannon is ally2...
            if (dP.ally2Name == "GlassCannon")
            {
                GlassCannonDefensiveAllyBranching(dP.ally2MoveSelected, dP.ally2TargetSelected);

                if (dP.ally2MoveSelected == "Defend") //If the move selected is Defend...
                {
                    ally2DEFbuff += 5;
                }
                if (dP.ally2MoveSelected == "Smoke Bomb" || dP.ally2MoveSelected == "Defend")
                {
                    dP.ally2MoveSelected = "";
                    dP.ally2TargetSelected = "";
                }
            }

            //If GlassCannon is ally3...
            if (dP.ally3Name == "GlassCannon")
            {
                GlassCannonDefensiveAllyBranching(dP.ally3MoveSelected, dP.ally3TargetSelected);

                if (dP.ally3MoveSelected == "Defend") //If the move selected is Defend...
                {
                    ally3DEFbuff += 5;
                }
                if (dP.ally3MoveSelected == "Smoke Bomb" || dP.ally3MoveSelected == "Defend")
                {
                    dP.ally3MoveSelected = "";
                    dP.ally3TargetSelected = "";
                }
            }
            ChangeCharacterTurnDefensivePhase(); //If the characterTurn was "GlassCannon", call the function.
        }
    }

    //Called when the characterTurn == "GlassCannon" and the move chosen was an offensive-type move.
    void GlassCannonOffensive()
    {
        /*if (characterTurn == "GlassCannon")
        {
            //If GlassCannon is ally1...
            if (dP.ally1Name == "GlassCannon")
            {
                if (dP.ally1MoveSelected == "Shard Shot") // If the move selected is Shard Shot...
                {
                    accuracy = Random.Range(1, 101);
                    bleedChance = Random.Range(1, 101);

                    if (dP.ally1TargetSelected == dP.enemy1Name && accuracy <= 70 && bleedChance > 30) //If the target selected is enemy1 and the accuracy is 70 or below...
                    {
                        dP.enemy1Health -= (15 + ally1STRbuff) - enemy1DEFbuff;
                        StartCoroutine(ShowDamageDealt(enemy1HealthLostText, ((15 + ally1STRbuff) - enemy1DEFbuff)));
                    }
                    else if (dP.ally1TargetSelected == dP.enemy1Name && accuracy <= 70 && bleedChance <= 30) //If the target selected is enemy1 and the accuracy is 70 or below and the bleedChance is 30 or below...
                    {
                        dP.enemy1Health -= (15 + ally1STRbuff) - enemy1DEFbuff;
                        StartCoroutine(ShowDamageDealt(enemy1HealthLostText, ((15 + ally1STRbuff) - enemy1DEFbuff)));
                        enemy1IsBleeding = 1;
                        StartCoroutine(ShowStatusEffect(enemy1StatusEffectText, "Bleeding"));
                    }
                    else if (dP.ally1TargetSelected == dP.enemy1Name && accuracy > 70) //If the target selected is enemy1 but it misses...
                    {
                        StartCoroutine(ShowMiss(enemy1MissText));
                    }
                    else if (dP.ally1TargetSelected == dP.enemy2Name && accuracy <= 70 && bleedChance > 30) //If the target selected is enemy2 and the accuracy is 70 or below...
                    {
                        dP.enemy2Health -= (15 + ally1STRbuff) - enemy2DEFbuff;
                        StartCoroutine(ShowDamageDealt(enemy2HealthLostText, ((15 + ally1STRbuff) - enemy2DEFbuff)));
                    }
                    else if (dP.ally1TargetSelected == dP.enemy2Name && accuracy <= 70 && bleedChance <= 30) //If the target selected is enemy2 and the accuracy is 70 or below and the bleedChance is 30 or below...
                    {
                        dP.enemy2Health -= (15 + ally1STRbuff) - enemy2DEFbuff;
                        StartCoroutine(ShowDamageDealt(enemy2HealthLostText, ((15 + ally1STRbuff) - enemy2DEFbuff)));
                        enemy2IsBleeding = 1;
                        StartCoroutine(ShowStatusEffect(enemy2StatusEffectText, "Bleeding"));
                    }
                    else if (dP.ally1TargetSelected == dP.enemy2Name && accuracy > 70) //If the target selected is enemy2 but it misses...
                    {
                        StartCoroutine(ShowMiss(enemy2MissText));
                    }
                    else if (dP.ally1TargetSelected == dP.enemy3Name && accuracy <= 70 && bleedChance > 30) //If the target selected is enemy3 and the accuracy is 70 or below...
                    {
                        dP.enemy3Health -= (15 + ally1STRbuff) - enemy3DEFbuff;
                        StartCoroutine(ShowDamageDealt(enemy3HealthLostText, ((15 + ally1STRbuff) - enemy3DEFbuff)));
                    }
                    else if (dP.ally1TargetSelected == dP.enemy3Name && accuracy <= 70 && bleedChance <= 30) //If the target selected is enemy3 and the accuracy is 70 or below and the bleedChance is 30 or below...
                    {
                        dP.enemy3Health -= (15 + ally1STRbuff) - enemy3DEFbuff;
                        StartCoroutine(ShowDamageDealt(enemy3HealthLostText, ((15 + ally1STRbuff) - enemy3DEFbuff)));
                        enemy3IsBleeding = 1;
                        StartCoroutine(ShowStatusEffect(enemy3StatusEffectText, "Bleeding"));
                    }
                    else if (dP.ally1TargetSelected == dP.enemy3Name && accuracy > 70) //If the target selected is enemy3 but it misses...
                    {
                        StartCoroutine(ShowMiss(enemy3MissText));
                    }
                }
            }

            //If GlassCannon is ally2...
            else if (dP.ally2Name == "GlassCannon")
            {

            }

            //If GlassCannon is ally3...
            else if (dP.ally3Name == "GlassCannon")
            {

            }
            ChangeCharacterTurnOffensivePhase(); //If the characterTurn was "GlassCannon", call the function.
        }*/

        if (characterTurn == "GlassCannon")
        {
            ChangeCharacterTurnOffensivePhase(true);
        }
    }

    void GlassCannonDefensiveAllyBranching(string MoveSelected, string TargetSelected)
    {
        if (MoveSelected == "Smoke Bomb") //If the move selected is Smoke bomb...
        {
            if (TargetSelected == dP.ally1Name) //If ally1 is targeted...
            {
                ally1HasSmokeBomb = true;
            }
            else if (TargetSelected == dP.ally2Name) //If ally2 is targeted...
            {
                ally2HasSmokeBomb = true;
            }
            else if (TargetSelected == dP.ally3Name) //If ally3 is targeted...
            {
                ally3HasSmokeBomb = true;
            }
        }
    }

    void SupportMainDefensive()
    {
        if (characterTurn == "SupportMain")
        {
            ChangeCharacterTurnDefensivePhase();
        }
    }

    void SupportMainOffensive()
    {
        if (characterTurn == "SupportMain")
        {
            ChangeCharacterTurnOffensivePhase(true);
        }
    }

    void SlimeDefensive()
    {
        if (characterTurn == "Slime1" || characterTurn == "Slime2" || characterTurn == "Slime3")
        {
            ChangeCharacterTurnDefensivePhase();
        }
    }

    void SlimeOffensive()
    {
        if (characterTurn == "Slime1" || characterTurn == "Slime2" || characterTurn == "Slime3")
        {
            ChangeCharacterTurnOffensivePhase(true);
        }
    }

    void Bleed() //Called in Update(); causes character to bleed for 2 rounds if active.
    {
        if (characterTurn == dP.enemy1Name && enemy1IsBleeding == 1 && enemy1HasBled == false) //If it's enemy1's turn and their turns bleeding is set to 1...
        {
            if (enemy1DEFbuff > 4)
            {
                StartCoroutine(ShowDamageDealt(enemy1HealthLostText, 0));
            }
            else
            {
                dP.enemy1Health -= (4 - enemy1DEFbuff);
            }
            enemy1IsBleeding = 2;
            enemy1HasBled = true;
        }
        else if (characterTurn == dP.enemy1Name && enemy1IsBleeding == 2 && enemy1HasBled == false) //If it's enemy1's turn and their turns bleeding is set to 2...
        {
            if (enemy1DEFbuff > 4)
            {
                StartCoroutine(ShowDamageDealt(enemy1HealthLostText, 0));
            }
            else
            {
                dP.enemy1Health -= (4 - enemy1DEFbuff);
            }
            enemy1IsBleeding = 0;
            enemy1HasBled = true;
        }

        if (characterTurn == dP.enemy2Name && enemy2IsBleeding == 1 && enemy2HasBled == false) //If it's enemy2's turn and their turns bleeding is set to 1...
        {
            if (enemy2DEFbuff > 4)
            {
                StartCoroutine(ShowDamageDealt(enemy2HealthLostText, 0));
            }
            else
            {
                dP.enemy2Health -= (4 - enemy2DEFbuff);
            }
            enemy2IsBleeding = 2;
            enemy2HasBled = true;
        }
        else if (characterTurn == dP.enemy2Name && enemy2IsBleeding == 2 && enemy2HasBled == false) //If it's enemy2's turn and their turns bleeding is set to 2...
        {
            if (enemy2DEFbuff > 4)
            {
                StartCoroutine(ShowDamageDealt(enemy2HealthLostText, 0));
            }
            else
            {
                dP.enemy2Health -= (4 - enemy2DEFbuff);
            }
            enemy2IsBleeding = 0;
            enemy2HasBled = true;
        }

        if (characterTurn == dP.enemy3Name && enemy3IsBleeding == 1 && enemy3HasBled == false) //If it's enemy3's turn and their turns bleeding is set to 1...
        {
            if (enemy3DEFbuff > 4)
            {
                StartCoroutine(ShowDamageDealt(enemy3HealthLostText, 0));
            }
            else
            {
                dP.enemy3Health -= (4 - enemy3DEFbuff);
            }
            enemy3IsBleeding = 2;
            enemy3HasBled = true;
        }
        else if (characterTurn == dP.enemy3Name && enemy3IsBleeding == 2 && enemy3HasBled == false) //If it's enemy3's turn and their turns bleeding is set to 2...
        {
            if (enemy3DEFbuff > 4)
            {
                StartCoroutine(ShowDamageDealt(enemy3HealthLostText, 0));
            }
            else
            {
                dP.enemy3Health -= (4 - enemy3DEFbuff);
            }
            enemy3IsBleeding = 0;
            enemy3HasBled = true;
        }
    }

    void ChangeCharacterTurnDefensivePhase() //Called when it's needed to change characterTurn during the DefensivePhase;  after enemy3's defensive phase turn is over set the defensivePhase bool to false.
    {
        //If the current turn is ally1...
        if (characterTurn == dP.ally1Name && dP.ally1MoveSelected == "") //If ally1 made a move during this phase...
        {
            StartCoroutine(CCTDPDowntime(dP.ally2Name));
        }
        else if (characterTurn == dP.ally1Name && dP.ally1MoveSelected != "") //If ally1 hasn't made a move during this phase...
        {
            characterTurn = dP.ally2Name;
        }

        //If the current turn is ally2...
        else if (characterTurn == dP.ally2Name && dP.ally2MoveSelected == "") //If ally2 made a move during this phase...
        {
            StartCoroutine(CCTDPDowntime(dP.ally3Name));
        }
        else if (characterTurn == dP.ally2Name && dP.ally2MoveSelected != "") //If ally2 hasn't made a move during this phase...
        {
            characterTurn = dP.ally3Name;
        }

        //If the current turn is ally3...
        else if (characterTurn == dP.ally3Name && dP.ally3MoveSelected == "") //If ally3 made a move during this phase...
        {
            StartCoroutine(CCTDPDowntime(dP.enemy1Name));
        }
        else if (characterTurn == dP.ally3Name && dP.ally3MoveSelected != "") //If ally3 hasn't made a move during this phase...
        {
            characterTurn = dP.enemy1Name;
        }

        //If the current turn is enemy1...
        else if (characterTurn == dP.enemy1Name && dP.enemy1MoveSelected == "") //If enemy1 made a move during this phase...
        {
            StartCoroutine(CCTDPDowntime(dP.enemy2Name));
        }
        else if (characterTurn == dP.enemy1Name && dP.enemy1MoveSelected != "") //If enemy1 hasn't made a move during this phase...
        {
            characterTurn = dP.enemy2Name;
        }

        //If the current turn is enemy2...
        else if (characterTurn == dP.enemy2Name && dP.enemy2MoveSelected == "") //If enemy2 made a move during this phase...
        {
            StartCoroutine(CCTDPDowntime(dP.enemy3Name));
        }
        else if (characterTurn == dP.enemy2Name && dP.enemy2MoveSelected != "") //If enemy2 hasn't made a move during this phase...
        {
            characterTurn = dP.enemy3Name;
        }

        //If the current turn is enemy3
        else if (characterTurn == dP.enemy3Name && dP.enemy3MoveSelected == "") //If enemy3 made a move during this phase...
        {
            StartCoroutine(CCTDPDowntime(dP.ally1Name, defensivePhase = false));
        }
        else if (characterTurn == dP.enemy3Name && dP.enemy3MoveSelected != "") //If enemy3 hasn't made a move during this phase...
        {
            characterTurn = dP.ally1Name;
            defensivePhase = false;
        }
    }

    IEnumerator CCTDPDowntime(string NextCharacterName, bool DefensivePhase = true) //To be called everytime the character turn in the DefensivePhase is to be changed after a character made a move. Waits 5 seconds before each change.
    {
        yield return new WaitForSeconds(5);
        characterTurn = NextCharacterName;
        defensivePhase = DefensivePhase;      
    }

    void ChangeCharacterTurnOffensivePhase(bool Skip = false) //Called when it's needed to change characterTurn during the OffensivePhase. After enemy3's turn is finished it'll turn off ActionPhase and set up variables for DecisionPhase.
    {
        //If the current turn is ally1...
        if (characterTurn == dP.ally1Name && Skip == false) //If ally1 made a move during this phase...
        {
            StartCoroutine(CCTOPDowntime(dP.ally2Name));
        }
        else if (characterTurn == dP.ally1Name && Skip == true) //If ally1 didn't made a move during this phase...
        {
            characterTurn = dP.ally2Name;
        }

        //If the current turn is ally2...
        else if (characterTurn == dP.ally2Name && Skip == false) //If ally2 made a move during this phase...
        {
            StartCoroutine(CCTOPDowntime(dP.ally3Name));
        }
        else if (characterTurn == dP.ally2Name && Skip == true) //If ally2 didn't made a move during this phase...
        {
            characterTurn = dP.ally3Name;
        }

        //If the current turn is ally3...
        else if (characterTurn == dP.ally3Name && Skip == false) //If ally3 made a move during this phase...
        {
            StartCoroutine(CCTOPDowntime(dP.enemy1Name));
        }
        else if (characterTurn == dP.ally3Name && Skip == true) //If ally3 didn't made a move during this phase...
        {
            characterTurn = dP.enemy1Name;
        }

        //If the current turn is enemy1...
        else if (characterTurn == dP.enemy1Name && Skip == false) //If enemy1 made a move during this phase...
        {
            StartCoroutine(CCTOPDowntime(dP.enemy2Name));
        }
        else if (characterTurn == dP.enemy1Name && Skip == true) //If enemy1 didn't made a move during this phase...
        {
            characterTurn = dP.enemy2Name;
        }

        //If the current turn is enemy2...
        else if (characterTurn == dP.enemy2Name && Skip == false) //If enemy2 made a move during this phase...
        {
            StartCoroutine(CCTOPDowntime(dP.enemy3Name));
        }
        else if (characterTurn == dP.enemy2Name && Skip == true) //If enemy2 didn't made a move during this phase...
        {
            characterTurn = dP.enemy3Name;
        }

        //If the current turn is enemy3...
        else if (characterTurn == dP.enemy3Name && Skip == false) //If enemy3 made a move during this phase...
        {
            StartCoroutine(CCTOPDowntimeFinal());
        }
        else if (characterTurn == dP.enemy3Name && Skip == true) //If enemy3 didn't made a move during this phase...
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
            dP.charactersTurnText.text = dP.characterTurn + "'s Turn";

            ally1HasBled = false;
            ally2HasBled = false;
            ally3HasBled = false;
            enemy1HasBled = false;
            enemy2HasBled = false;
            enemy3HasBled = false;
        }

        /*if (characterTurn == dP.ally1Name)
        {
            StartCoroutine(CCTOPDowntime(dP.ally2Name));
        }
        else if (characterTurn == dP.ally2Name)
        {
            StartCoroutine(CCTOPDowntime(dP.ally3Name));
        }
        else if (characterTurn == dP.ally3Name)
        {
            StartCoroutine(CCTOPDowntime(dP.enemy1Name));
        }
        else if (characterTurn == dP.enemy1Name)
        {
            StartCoroutine(CCTOPDowntime(dP.enemy2Name));
        }
        else if (characterTurn == dP.enemy2Name)
        {
            StartCoroutine(CCTOPDowntime(dP.enemy2Name));
        }
        else if (characterTurn == dP.enemy3Name)
        {
            StartCoroutine(CCTOPDowntimeFinal());
        }*/
    }

    IEnumerator CCTOPDowntime(string NextCharacterName) //To be called everytime the character turn in the OffensivePhase is to be changed after a character made a move. Waits 5 seconds before each change.
    {
        yield return new WaitForSeconds(5);
        characterTurn = NextCharacterName;
    }

    IEnumerator CCTOPDowntimeFinal() //To be called after the final character turn in the OffensivePhase. Waits 5 seconds before each change.
    {
        yield return new WaitForSeconds(5);
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
        dP.charactersTurnText.text = dP.characterTurn + "'s Turn";

        ally1HasBled = false;
        ally2HasBled = false;
        ally3HasBled = false;
        enemy1HasBled = false;
        enemy2HasBled = false;
        enemy3HasBled = false;
    }

    IEnumerator ShowStatusEffect(TextMeshProUGUI CharacterEffected, string StatusEffect) //When called, shows the inflicted status effect of the character for 3 seconds.
    {
        CharacterEffected.text = StatusEffect;
        yield return new WaitForSeconds(3);
        CharacterEffected.text = "";
    }

    IEnumerator ShowDamageDealt(TextMeshProUGUI CharacterHealthLost, int AmountLost) //When called, shows the damage dealt to the character for 3 seconds.
    {
        CharacterHealthLost.text = "- " + AmountLost;
        yield return new WaitForSeconds(3);
        CharacterHealthLost.text = "";
    }

    IEnumerator ShowMiss(TextMeshProUGUI CharacterMissText) //When called, shows the damage dealt to the character for 3 seconds.
    {
        CharacterMissText.text = "MISS";
        yield return new WaitForSeconds(3);
        CharacterMissText.text = "";
    }
}
