using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combat : MonoBehaviour
{
    [Header("TextObjects")]
    public TextMeshProUGUI ally1HealthText;
    public TextMeshProUGUI ally2HealthText;
    public TextMeshProUGUI ally3HealthText;
    public TextMeshProUGUI enemy1HealthText;
    public TextMeshProUGUI enemy2HealthText;
    public TextMeshProUGUI enemy3HealthText;
    public TextMeshProUGUI charactersTurnText;
    public GameObject selectATargetText;

    [Space]
    [Header("GameObjects")]
    public GameObject ally1;
    public GameObject ally2;
    public GameObject ally3;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    [Space]
    [Header("CharacterInfo")]
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

    private int ally1Health = 0;
    private int ally2Health = 0;
    private int ally3Health = 0;
    private int enemy1Health = 0;
    private int enemy2Health = 0;
    private int enemy3Health = 0;

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

    private bool selectAnEnemy = false;
    private bool selectAnAlly = false;
    private string ally1TargetSelected = "";
    private string ally2TargetSelected = "";
    private string ally3TargetSelected = "";
    private string enemy1TargetSelected = "";
    private string enemy2TargetSelected = "";
    private string enemy3TargetSelected = "";

    private string characterTurn = "";

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
    }

    // Update is called once per frame
    void Update()
    {

        RefreshHealthText(); //Calls RefreshHealthText every frame in order to update the health text

        if (selectAnEnemy == true) //If the player is required to select an enemy the player will be able to click on one of the enemy colliders.
        {
            selectATargetText.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider.gameObject.name == enemy1Name || hit.collider.gameObject.name == enemy2Name || hit.collider.gameObject.name == enemy3Name)
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
            }
        }

        if (selectAnAlly == true) //If the player is required to select an ally the player will be able to click on one of the ally colliders.
        {
            selectATargetText.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

                RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
                if (hit.collider.gameObject.name == ally1Name || hit.collider.gameObject.name == ally2Name || hit.collider.gameObject.name == ally3Name)
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
            }
        }
      
        //If one of the character's health equals or is below 0, call CharacterDeath().
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

    void RefreshHealthText() //Refreshes health text each frame
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
    }

    void Ally3MoveChosen() //Called once the third ally's turn is over.
    {
        ally3Move1.SetActive(false);
        ally3Move2.SetActive(false);
        ally3Move3.SetActive(false);
        ally3Move4.SetActive(false);
        defendMove.SetActive(false);

        characterTurn = "";
        charactersTurnText.text = "";
    }
}
