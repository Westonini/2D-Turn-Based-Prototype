using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combat : MonoBehaviour
{
    [Header("Text Objects")]
    public TextMeshProUGUI ally1HealthText;
    public TextMeshProUGUI ally2HealthText;
    public TextMeshProUGUI ally3HealthText;
    public TextMeshProUGUI enemy1HealthText;
    public TextMeshProUGUI enemy2HealthText;
    public TextMeshProUGUI enemy3HealthText;
    public TextMeshProUGUI charactersTurnText;
    public GameObject selectATargetText;
    public GameObject cMLeftSprite;
    public Animator cMLeftSpriteAnim;
    public TextMeshProUGUI cMLeftCharacterName;
    public TextMeshProUGUI cMLeftCharacterHealthText;
    public GameObject cMRightSprite;
    public Animator cMRightSpriteAnim;
    public TextMeshProUGUI cMRightCharacterName;
    public TextMeshProUGUI cMRightCharacterHealthText;
    public TextMeshProUGUI cMMoveInfo;

    [Space]
    [Header("Character GameObjects")]
    public GameObject ally1;
    public GameObject ally2;
    public GameObject ally3;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    [Space]
    [Header("Character Animators")]
    public Animator ally1Anim;
    public Animator ally2Anim;
    public Animator ally3Anim;
    public Animator enemy1Anim;
    public Animator enemy2Anim;
    public Animator enemy3Anim;

    [Space]
    [Header("Character Info")]
    public int ally1MaxHealth;  
    public int ally2MaxHealth;   
    public int ally3MaxHealth;   
    public int enemy1MaxHealth;   
    public int enemy2MaxHealth;   
    public int enemy3MaxHealth;
    private string ally1Name;
    private string ally2Name;
    private string ally3Name;
    private string enemy1Name;
    private string enemy2Name;
    private string enemy3Name;

    [Space]
    [Header("Buttons")]
    public GameObject Move1Button;
    public GameObject Move2Button;
    public GameObject Move3Button;
    public GameObject Move4Button;
    public GameObject DefendButton;
    [Space]
    public GameObject ally1Move1;
    public GameObject ally1Move2;
    public GameObject ally1Move3;
    public GameObject ally1Move4;
    public GameObject ally2Move1;
    public GameObject ally2Move2;
    public GameObject ally2Move3;
    public GameObject ally2Move4;
    public GameObject ally3Move1;
    public GameObject ally3Move2;
    public GameObject ally3Move3;
    public GameObject ally3Move4;
    public GameObject defendMove;

    [HideInInspector]
    public int ally1Health = 0, ally2Health = 0, ally3Health = 0, enemy1Health = 0, enemy2Health = 0, enemy3Health = 0;

    private bool ally1Dead = false;
    private bool ally2Dead = false;
    private bool ally3Dead = false;
    private bool enemy1Dead = false;
    private bool enemy2Dead = false;
    private bool enemy3Dead = false;

    private string ally1MoveSelected = "";
    private string ally2MoveSelected = "";
    private string ally3MoveSelected = "";
    private string enemy1MoveSelected = "";
    private string enemy2MoveSelected = "";
    private string enemy3MoveSelected = "";

    [HideInInspector]
    public bool selectAnEnemy = false;
    [HideInInspector]
    public bool selectAnAlly = false;
    [HideInInspector]
    public bool selectAllTargets = false;
    private string ally1TargetSelected = "";
    private string ally2TargetSelected = "";
    private string ally3TargetSelected = "";
    private string enemy1TargetSelected = "";
    private string enemy2TargetSelected = "";
    private string enemy3TargetSelected = "";

    private bool ally1IsCharging = false;
    private bool ally2IsCharging = false;
    private bool ally3IsCharging = false;
    private bool enemy1IsCharging = false;
    private bool enemy2IsCharging = false;
    private bool enemy3IsCharging = false;

    [HideInInspector]
    public string characterTurn = "";

    void Awake()
    {
        cMLeftSpriteAnim = cMLeftSprite.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        ally1Health = ally1MaxHealth;
        ally2Health = ally2MaxHealth;
        ally3Health = ally3MaxHealth;
        enemy1Health = enemy1MaxHealth;
        enemy2Health = enemy2MaxHealth;
        enemy3Health = enemy3MaxHealth;

        ally1Name = ally1.name.ToString();
        ally2Name = ally2.name.ToString();
        ally3Name = ally3.name.ToString();
        enemy1Name = enemy1.name.ToString();
        enemy2Name = enemy2.name.ToString();
        enemy3Name = enemy3.name.ToString();

        characterTurn = ally1Name;

        Move1Button.SetActive(true);
        Move2Button.SetActive(true);
        Move3Button.SetActive(true);
        Move4Button.SetActive(true);
        DefendButton.SetActive(true);
        ally1Move1.SetActive(true);
        ally1Move2.SetActive(true);
        ally1Move3.SetActive(true);
        ally1Move4.SetActive(true);
        defendMove.SetActive(true);

        characterTurn = ally1Name;
        charactersTurnText.text = characterTurn + "'s Turn";
    }

    // Update is called once per frame
    void Update()
    {
        RefreshHealthText(); //Calls RefreshHealthText every frame in order to update the health text.

        TargetSelection(); //Calls TargetSelection every frame in order to select a target when needed.

        CheckIfDead(); //Calls CheckIfDead every frame to check if a character's HP is 0 or lower.
    }

    public void Move1Selected() //Called when the Move1 Button is clicked.
    {
        if (characterTurn == "HeroProtagonist") //If the character's name is HeroProtagonist and they choose Move1...
        {
            if (ally1Name == "HeroProtagonist")
            {
                ally1MoveSelected = "Sword Slash";
                selectAnEnemy = true;
            }
            else if (ally2Name == "HeroProtagonist")
            {
                ally2MoveSelected = "Sword Slash";
                selectAnEnemy = true;
            }
            else if (ally3Name == "HeroProtagonist")
            {
                ally3MoveSelected = "Sword Slash";
                selectAnEnemy = true;
            }     
        }
        else if (characterTurn == "GlassCannon") //If the character's name is GlassCannon and they choose Move1...
        {
            if (ally1Name == "GlassCannon")
            {
                ally1MoveSelected = "Shard Shot";
                selectAnEnemy = true;
            }
            else if (ally2Name == "GlassCannon")
            {
                ally2MoveSelected = "Shard Shot";
                selectAnEnemy = true;
            }
            else if (ally3Name == "GlassCannon")
            {
                ally3MoveSelected = "Shard Shot";
                selectAnEnemy = true;
            }

        }
        else if (characterTurn == "SupportMain") //If the character's name is SupportMain and they choose Move1...
        {
            if (ally1Name == "SupportMain")
            {
                ally1MoveSelected = "Mend";
                selectAnAlly = true;
            }
            else if (ally2Name == "SupportMain")
            {
                ally2MoveSelected = "Mend";
                selectAnAlly = true;
            }
            else if (ally3Name == "SupportMain")
            {
                ally3MoveSelected = "Mend";
                selectAnAlly = true;
            }
        }
    }

    public void Move2Selected() //Called when the Move2 Button is clicked.
    {
        if (characterTurn == "HeroProtagonist") //If the character's name is HeroProtagonist and they choose Move2...
        {
            if (ally1Name == "HeroProtagonist")
            {
                ally1MoveSelected = "War Cry";
                selectAnAlly = true;
            }
            else if (ally2Name == "HeroProtagonist")
            {
                ally2MoveSelected = "War Cry";
                selectAnAlly = true;
            }
            else if (ally3Name == "HeroProtagonist")
            {
                ally3MoveSelected = "War Cry";
                selectAnAlly = true;
            }
        }
        else if (characterTurn == "GlassCannon") //If the character's name is GlassCannon and they choose Move2...
        {
            if (ally1Name == "GlassCannon")
            {
                ally1MoveSelected = "Shatter";
                selectAnEnemy = true;
                selectAllTargets = true;
            }
            else if (ally2Name == "GlassCannon")
            {
                ally2MoveSelected = "Shatter";
                selectAnEnemy = true;
                selectAllTargets = true;
            }
            else if (ally3Name == "GlassCannon")
            {
                ally3MoveSelected = "Shatter";
                selectAnEnemy = true;
                selectAllTargets = true;
            }
        }
        else if (characterTurn == "SupportMain") //If the character's name is SupportMain and they choose Move2...
        {
            if (ally1Name == "SupportMain")
            {
                ally1MoveSelected = "Buckle Down";
                selectAnAlly = true;
                selectAllTargets = true;
            }
            else if (ally2Name == "SupportMain")
            {
                ally2MoveSelected = "Buckle Down";
                selectAnAlly = true;
                selectAllTargets = true;
            }
            else if (ally3Name == "SupportMain")
            {
                ally3MoveSelected = "Buckle Down";
                selectAnAlly = true;
                selectAllTargets = true;
            }
        }
    }

    public void Move3Selected() //Called when the Move3 Button is clicked.
    {
        if (characterTurn == "HeroProtagonist") //If the character's name is HeroProtagonist and they choose Move3...
        {
            if (ally1Name == "HeroProtagonist")
            {
                ally1MoveSelected = "Windmill";
                selectAnEnemy = true;
                selectAllTargets = true;
            }
            else if (ally2Name == "HeroProtagonist")
            {
                ally2MoveSelected = "Windmill";
                selectAnEnemy = true;
                selectAllTargets = true;
            }
            else if (ally3Name == "HeroProtagonist")
            {
                ally3MoveSelected = "Windmill";
                selectAnEnemy = true;
                selectAllTargets = true;
            }
        }
        else if (characterTurn == "GlassCannon") //If the character's name is GlassCannon and they choose Move3...
        {
            if (ally1Name == "GlassCannon")
            {
                ally1MoveSelected = "Focus Shot";
                ChargeMove();
                selectAnEnemy = true;
            }
            else if (ally2Name == "GlassCannon")
            {
                ally2MoveSelected = "Focus Shot";
                ChargeMove();
                selectAnEnemy = true;
            }
            else if (ally3Name == "GlassCannon")
            {
                ally3MoveSelected = "Focus Shot";
                ChargeMove();
                selectAnEnemy = true;
            }
        }
        else if (characterTurn == "SupportMain") //If the character's name is SupportMain and they choose Move3...
        {
            if (ally1Name == "SupportMain")
            {
                ally1MoveSelected = "Leech";
                selectAnEnemy = true;
            }
            else if (ally2Name == "SupportMain")
            {
                ally2MoveSelected = "Leech";
                selectAnEnemy = true;
            }
            else if (ally3Name == "SupportMain")
            {
                ally3MoveSelected = "Leech";
                selectAnEnemy = true;
            }
        }
    }

    public void Move4Selected() //Called when the Move4 Button is clicked.
    {
        if (characterTurn == "HeroProtagonist") //If the character's name is HeroProtagonist and they choose Move4...
        {
            if (ally1Name == "HeroProtagonist")
            {
                ally1MoveSelected = "Bandage-Up";
                selectAnAlly = true;
            }
            else if (ally2Name == "HeroProtagonist")
            {
                ally2MoveSelected = "Bandage-Up";
                selectAnAlly = true;
            }
            else if (ally3Name == "HeroProtagonist")
            {
                ally3MoveSelected = "Bandage-Up";
                selectAnAlly = true;
            }
        }
        else if (characterTurn == "GlassCannon") //If the character's name is GlassCannon and they choose Move4...
        {
            if (ally1Name == "GlassCannon")
            {
                ally1MoveSelected = "Smoke Bomb";
                selectAnAlly = true;
            }
            else if (ally2Name == "GlassCannon")
            {
                ally2MoveSelected = "Smoke Bomb";
                selectAnAlly = true;
            }
            else if (ally3Name == "GlassCannon")
            {
                ally3MoveSelected = "Smoke Bomb";
                selectAnAlly = true;
            }
        }
        else if (characterTurn == "SupportMain") //If the character's name is SupportMain and they choose Move4...
        {
            if (ally1Name == "SupportMain")
            {
                ally1MoveSelected = "Mend-All";
                selectAnAlly = true;
                selectAllTargets = true;
            }
            else if (ally2Name == "SupportMain")
            {
                ally2MoveSelected = "Mend-All";
                selectAnAlly = true;
                selectAllTargets = true;
            }
            else if (ally3Name == "SupportMain")
            {
                ally3MoveSelected = "Mend-All";
                selectAnAlly = true;
                selectAllTargets = true;
            }
        }
    }

    public void DefendSelected() //Called when the Defend Button is clicked
    {
        if (characterTurn == ally1Name)
        {
            ally1MoveSelected = "Defend";
            Ally1MoveChosen();
        }
        else if (characterTurn == ally2Name)
        {
            ally2MoveSelected = "Defend";
            Ally2MoveChosen();
        }
        else if (characterTurn == ally3Name)
        {
            ally3MoveSelected = "Defend";
            Ally3MoveChosen();
        }
    }

    void CharacterDeath(GameObject character, bool isDead, TextMeshProUGUI healthText) //Called when a character dies; Takes the character's gameObject, their isDead bool, and their healthtext.
    {
        character.SetActive(false);
        isDead = true;
        healthText.text = "";
    }

    void RefreshHealthText() //Called in Update(); Refreshes health text each frame
    {
        if (ally1Dead != true)
        {
            ally1HealthText.text = "HP: " + ally1Health.ToString() + " / " + ally1MaxHealth.ToString();
        }
        if (ally2Dead != true)
        {
            ally2HealthText.text = "HP: " + ally2Health.ToString() + " / " + ally2MaxHealth.ToString();
        }
        if (ally3Dead != true)
        {
            ally3HealthText.text = "HP: " + ally3Health.ToString() + " / " + ally3MaxHealth.ToString();
        }
        if (enemy1Dead != true)
        {
            enemy1HealthText.text = "HP: " + enemy1Health.ToString() + " / " + enemy1MaxHealth.ToString();
        }
        if (enemy2Dead != true)
        {
            enemy2HealthText.text = "HP: " + enemy2Health.ToString() + " / " + enemy2MaxHealth.ToString();
        }
        if (enemy3Dead != true)
        {
            enemy3HealthText.text = "HP: " + enemy3Health.ToString() + " / " + enemy3MaxHealth.ToString();
        }

        //Updates the CombatMenu LeftSprite, LeftCharacterName, and LeftHealth
        if (characterTurn == "HeroProtagonist")
        {
            cMLeftSpriteAnim.SetBool("LSGlassCannon", false);
            cMLeftSpriteAnim.SetBool("LSSupportMain", false);

            if (ally1Name == "HeroProtagonist")
            {
                cMLeftCharacterHealthText.text = "HP: \n" + ally1Health.ToString() + " / " + ally1MaxHealth.ToString();
                cMLeftCharacterName.text = "HeroProtagonist";
                cMLeftSpriteAnim.SetBool("LSHeroProtagonist", true);
            }
            else if (ally2Name == "HeroProtagonist")
            {
                cMLeftCharacterHealthText.text = "HP: \n" + ally2Health.ToString() + " / " + ally2MaxHealth.ToString();
                cMLeftCharacterName.text = "HeroProtagonist";
                cMLeftSpriteAnim.SetBool("LSHeroProtagonist", true);
            }
            else if (ally3Name == "HeroProtagonist")
            {
                cMLeftCharacterHealthText.text = "HP: \n" + ally3Health.ToString() + " / " + ally3MaxHealth.ToString();
                cMLeftCharacterName.text = "HeroProtagonist";
                cMLeftSpriteAnim.SetBool("LSHeroProtagonist", true);
            }
        }
        else if (characterTurn == "GlassCannon")
        {
            cMLeftSpriteAnim.SetBool("LSHeroProtagonist", false);
            cMLeftSpriteAnim.SetBool("LSSupportMain", false);

            if (ally1Name == "GlassCannon")
            {
                cMLeftCharacterHealthText.text = "HP: \n" + ally1Health.ToString() + " / " + ally1MaxHealth.ToString();
                cMLeftCharacterName.text = "GlassCannon";
                cMLeftSpriteAnim.SetBool("LSGlassCannon", true);
            }
            else if (ally2Name == "GlassCannon")
            {
                cMLeftCharacterHealthText.text = "HP: \n" + ally2Health.ToString() + " / " + ally2MaxHealth.ToString();
                cMLeftCharacterName.text = "GlassCannon";
                cMLeftSpriteAnim.SetBool("LSGlassCannon", true);
            }
            else if (ally3Name == "GlassCannon")
            {
                cMLeftCharacterHealthText.text = "HP: \n" + ally3Health.ToString() + " / " + ally3MaxHealth.ToString();
                cMLeftCharacterName.text = "GlassCannon";
                cMLeftSpriteAnim.SetBool("LSGlassCannon", true);
            }
        }
        else if (characterTurn == "SupportMain")
        {
            cMLeftSpriteAnim.SetBool("LSHeroProtagonist", false);
            cMLeftSpriteAnim.SetBool("LSGlassCannon", false);

            if (ally1Name == "SupportMain")
            {
                cMLeftCharacterHealthText.text = "HP: \n" + ally1Health.ToString() + " / " + ally1MaxHealth.ToString();
                cMLeftCharacterName.text = "SupportMain";
                cMLeftSpriteAnim.SetBool("LSSupportMain", true);
            }
            else if (ally2Name == "SupportMain")
            {
                cMLeftCharacterHealthText.text = "HP: \n" + ally2Health.ToString() + " / " + ally2MaxHealth.ToString();
                cMLeftCharacterName.text = "SupportMain";
                cMLeftSpriteAnim.SetBool("LSSupportMain", true);
            }
            else if (ally3Name == "SupportMain")
            {
                cMLeftCharacterHealthText.text = "HP: \n" + ally3Health.ToString() + " / " + ally3MaxHealth.ToString();
                cMLeftCharacterName.text = "SupportMain";
                cMLeftSpriteAnim.SetBool("LSSupportMain", true);
            }
        }
        else if (characterTurn == "")
        {
            { 
                cMLeftSpriteAnim.SetBool("LSHeroProtagonist", false);
                cMLeftSpriteAnim.SetBool("LSGlassCannon", false);
                cMLeftSpriteAnim.SetBool("LSSupportMain", false);

                cMLeftCharacterHealthText.text = "";
                cMLeftCharacterName.text = "";
            }
        }
    }

    void Ally1MoveChosen() //Called once the first ally's turn is over.
    {
        ally1Move1.SetActive(false);
        ally1Move2.SetActive(false);
        ally1Move3.SetActive(false);
        ally1Move4.SetActive(false);
        ally2Move1.SetActive(true);
        ally2Move2.SetActive(true);
        ally2Move3.SetActive(true);
        ally2Move4.SetActive(true);

        characterTurn = ally2Name;
        charactersTurnText.text = characterTurn + "'s Turn";
        cMMoveInfo.text = "";
    }

    void Ally2MoveChosen() //Called once the second ally's turn is over.
    {
        ally2Move1.SetActive(false);
        ally2Move2.SetActive(false);
        ally2Move3.SetActive(false);
        ally2Move4.SetActive(false);
        ally3Move1.SetActive(true);
        ally3Move2.SetActive(true);
        ally3Move3.SetActive(true);
        ally3Move4.SetActive(true);

        characterTurn = ally3Name;
        charactersTurnText.text = characterTurn + "'s Turn";
        cMMoveInfo.text = "";
    }

    void Ally3MoveChosen() //Called once the third ally's turn is over.
    {
        ally3Move1.SetActive(false);
        ally3Move2.SetActive(false);
        ally3Move3.SetActive(false);
        ally3Move4.SetActive(false);
        defendMove.SetActive(false);

        Move1Button.SetActive(false);
        Move2Button.SetActive(false);
        Move3Button.SetActive(false);
        Move4Button.SetActive(false);
        DefendButton.SetActive(false);

        characterTurn = "";
        charactersTurnText.text = "";
        cMMoveInfo.text = "";
    }

    void ChargeMove() //Called when a move requires a round to charge.
    {
        if (characterTurn == ally1Name)
        {
            ally1IsCharging = true;
        }
        else if (characterTurn == ally2Name)
        {
            ally2IsCharging = true;
        }
        else if (characterTurn == ally3Name)
        {
            ally3IsCharging = true;
        }
    }

    void TargetSelection() //Called in Update(); used to select targets for moves.
    {
        if (selectAnEnemy == true || selectAnAlly == true) //If the player is required to select an enemy or ally, the player will be able to click on one of the enemy or ally colliders.
        {
            selectATargetText.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                try
                {
                    if (selectAnEnemy == true && selectAllTargets == false) //Used for when the player needs to select an enemy.
                    {
                        if (hit.collider.gameObject.name == enemy1Name || hit.collider.gameObject.name == enemy2Name || hit.collider.gameObject.name == enemy3Name) //If the player selects an enemy, add the target's name to the ally's TargetSelected
                        {
                            if (characterTurn == ally1Name)
                            {
                                ally1TargetSelected = hit.collider.gameObject.name.ToString();
                                Ally1MoveChosen();
                            }
                            else if (characterTurn == ally2Name)
                            {
                                ally2TargetSelected = hit.collider.gameObject.name.ToString();
                                Ally2MoveChosen();
                            }
                            else if (characterTurn == ally3Name)
                            {
                                ally3TargetSelected = hit.collider.gameObject.name.ToString();
                                Ally3MoveChosen();
                            }

                            selectATargetText.SetActive(false);
                            selectAnEnemy = false;
                        }
                        else if (hit.collider.gameObject.name == ally1Name || hit.collider.gameObject.name == ally2Name || hit.collider.gameObject.name == ally3Name) //If the player selects an ally, cancel the selection.
                        {
                            selectAnAlly = false;
                            selectAnEnemy = false;
                            selectAllTargets = false;
                            selectATargetText.SetActive(false);
                        }
                    }
                    else if (selectAnEnemy == true && selectAllTargets == true) //Used for when the player needs to select an enemy, but it's TargetAll move.
                    {
                        if (hit.collider.gameObject.name == enemy1Name || hit.collider.gameObject.name == enemy2Name || hit.collider.gameObject.name == enemy3Name) //If the player selects any enemy, make the ally's TargetSelected "All Enemies".
                        {
                            if (characterTurn == ally1Name)
                            {
                                ally1TargetSelected = "All Enemies";
                                Ally1MoveChosen();
                            }
                            else if (characterTurn == ally2Name)
                            {
                                ally2TargetSelected = "All Enemies";
                                Ally2MoveChosen();
                            }
                            else if (characterTurn == ally3Name)
                            {
                                ally3TargetSelected = "All Enemies";
                                Ally3MoveChosen();
                            }

                            selectATargetText.SetActive(false);
                            selectAnEnemy = false;
                            selectAllTargets = false;
                        }
                        else if (hit.collider.gameObject.name == ally1Name || hit.collider.gameObject.name == ally2Name || hit.collider.gameObject.name == ally3Name) //If the player selects an ally, cancel the selection.
                        {
                            selectAnAlly = false;
                            selectAnEnemy = false;
                            selectAllTargets = false;
                            selectATargetText.SetActive(false);
                        }
                    }
                    else if (selectAnAlly == true && selectAllTargets == false) //Used for when the player needs to select an ally.
                    {
                        if (hit.collider.gameObject.name == ally1Name || hit.collider.gameObject.name == ally2Name || hit.collider.gameObject.name == ally3Name) //If the player selects an ally, add the target's name to the ally's TargetSelected.
                        {
                            if (characterTurn == ally1Name)
                            {
                                ally1TargetSelected = hit.collider.gameObject.name.ToString();
                                Ally1MoveChosen();
                            }
                            else if (characterTurn == ally2Name)
                            {
                                ally2TargetSelected = hit.collider.gameObject.name.ToString();
                                Ally2MoveChosen();
                            }
                            else if (characterTurn == ally3Name)
                            {
                                ally3TargetSelected = hit.collider.gameObject.name.ToString();
                                Ally3MoveChosen();
                            }

                            selectATargetText.SetActive(false);
                            selectAnAlly = false;
                        }
                        else if (hit.collider.gameObject.name == enemy1Name || hit.collider.gameObject.name == enemy2Name || hit.collider.gameObject.name == enemy3Name) //If the player selects an enemy, cancel the selection.
                        {
                            selectAnAlly = false;
                            selectAnEnemy = false;
                            selectAllTargets = false;
                            selectATargetText.SetActive(false);
                        }
                    }
                    else if (selectAnAlly == true && selectAllTargets == true) //Used for when the player needs to select an ally, but it's TargetAll move.
                    {
                        if (hit.collider.gameObject.name == ally1Name || hit.collider.gameObject.name == ally2Name || hit.collider.gameObject.name == ally3Name) //If the player selects any ally, make the ally's TargetSelected "All Allies".
                        {
                            if (characterTurn == ally1Name)
                            {
                                ally1TargetSelected = "All Allies";
                                Ally1MoveChosen();
                            }
                            else if (characterTurn == ally2Name)
                            {
                                ally2TargetSelected = "All Allies";
                                Ally2MoveChosen();
                            }
                            else if (characterTurn == ally3Name)
                            {
                                ally3TargetSelected = "All Allies";
                                Ally3MoveChosen();
                            }

                            selectATargetText.SetActive(false);
                            selectAnAlly = false;
                            selectAllTargets = false;
                        }
                        else if (hit.collider.gameObject.name == enemy1Name || hit.collider.gameObject.name == enemy2Name || hit.collider.gameObject.name == enemy3Name) //If the player selects an enemy, cancel the selection.
                        {
                            selectAnAlly = false;
                            selectAnEnemy = false;
                            selectAllTargets = false;
                            selectATargetText.SetActive(false);
                        }
                    }
                }
                catch //If the player selects neither the enemies or allies, cancel the selection.
                {
                    selectAnAlly = false;
                    selectAnEnemy = false;
                    selectAllTargets = false;
                    selectATargetText.SetActive(false);
                }
            }
        }
    }

    void CheckIfDead() //Called in Update(); If one of the character's health equals or is below 0, call CharacterDeath().
    {       
        if (ally1Health <= 0)
        {
            CharacterDeath(ally1, ally1Dead, ally1HealthText);
        }
        if (ally2Health <= 0)
        {
            CharacterDeath(ally2, ally2Dead, ally2HealthText);
        }
        if (ally3Health <= 0)
        {
            CharacterDeath(ally3, ally3Dead, ally3HealthText);
        }
        if (enemy1Health <= 0)
        {
            CharacterDeath(enemy1, enemy1Dead, enemy1HealthText);
        }
        if (enemy2Health <= 0)
        {
            CharacterDeath(enemy2, enemy2Dead, enemy2HealthText);
        }
        if (enemy3Health <= 0)
        {
            CharacterDeath(enemy3, enemy3Dead, enemy3HealthText);
        }
    }
}
