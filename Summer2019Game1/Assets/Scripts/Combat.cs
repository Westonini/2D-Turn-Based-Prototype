using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combat : MonoBehaviour
{
    [Header("TextObjects")]
    public TextMeshProUGUI heroProtagHealthText;
    public TextMeshProUGUI glassCannonHealthText;
    public TextMeshProUGUI supportMainHealthText;
    public TextMeshProUGUI enemy1HealthText;
    public TextMeshProUGUI enemy2HealthText;
    public TextMeshProUGUI enemy3HealthText;

    [Space]
    [Header("GameObjects")]
    public GameObject heroProtagonist;
    public GameObject glassCannon;
    public GameObject supportMain;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;

    private int heroProtagHealthMAX = 50;
    private int glassCannonHealthMAX = 25;
    private int supportMainHealthMAX = 40;
    private int enemy1HealthMAX = 30;
    private int enemy2HealthMAX = 30;
    private int enemy3HealthMAX = 30;

    private int heroProtagHealth = 50;
    private int glassCannonHealth = 25;
    private int supportMainHealth = 40;
    private int enemy1Health = 30;
    private int enemy2Health = 30;
    private int enemy3Health = 30;

    private bool heroProtagDead = false;
    private bool glassCannonDead = false;
    private bool supportMainDead = false;
    private bool enemy1Dead = false;
    private bool enemy2Dead = false;
    private bool enemy3Dead = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RefreshHealthText(); //Calls RefreshHealthText every frame in order to update the health text

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (enemy1Health >= 1)
            {
                enemy1Health -= 10;
            }
        }


        if (heroProtagHealth <= 0)
        {
            CharacterDeath(heroProtagonist, heroProtagDead, heroProtagHealthText);
        }
        if (glassCannonHealth <= 0)
        {
            CharacterDeath(glassCannon, glassCannonDead, glassCannonHealthText);
        }
        if (supportMainHealth <= 0)
        {
            CharacterDeath(supportMain, supportMainDead, supportMainHealthText);
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

    void CharacterDeath(GameObject character, bool isDead, TextMeshProUGUI healthText) //Called when a character dies; Takes the character's gameObject, their isDead bool, and their healthtext.
    {
        character.SetActive(false);
        isDead = true;
        healthText.text = "";
    }

    void RefreshHealthText() //Refreshes health text each frame
    {
        if (heroProtagDead != true)
        {
            heroProtagHealthText.text = "HP: " + heroProtagHealth.ToString() + " / " + heroProtagHealthMAX.ToString();
        }
        if (glassCannonDead != true)
        {
            glassCannonHealthText.text = "HP: " + glassCannonHealth.ToString() + " / " + glassCannonHealthMAX.ToString();
        }
        if (supportMainDead != true)
        {
            supportMainHealthText.text = "HP: " + supportMainHealth.ToString() + " / " + supportMainHealthMAX.ToString();
        }
        if (enemy1Dead != true)
        {
            enemy1HealthText.text = "HP: " + enemy1Health.ToString() + " / " + enemy1HealthMAX.ToString();
        }
        if (enemy2Dead != true)
        {
            enemy2HealthText.text = "HP: " + enemy2Health.ToString() + " / " + enemy2HealthMAX.ToString();
        }
        if (enemy3Dead != true)
        {
            enemy3HealthText.text = "HP: " + enemy3Health.ToString() + " / " + enemy3HealthMAX.ToString();
        }
    }
}
