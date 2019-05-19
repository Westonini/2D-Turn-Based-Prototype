using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combat : MonoBehaviour
{
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI glassCannonHealthText;
    public TextMeshProUGUI enemy1HealthText;
    private int playerHealthMAX = 50;
    private int glassCannonHealthMAX = 30;
    private int enemy1HealthMAX = 50;

    private int playerHealth = 50;
    private int glassCannonHealth = 30;
    private int enemy1Health = 50;

    private bool playerDead = false;
    private bool glassCannonDead = false;
    private bool enemy1Dead = false;

    public GameObject player;
    public GameObject glassCannon;
    public GameObject enemy1;


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
            if (playerHealth >= 1)
            {
                playerHealth -= 10;
            }
        }

        if (enemy1Health <= 0)
        {
            CharacterDeath(enemy1, enemy1Dead, enemy1HealthText);
        }
        if (playerHealth <= 0)
        {
            CharacterDeath(player, playerDead, playerHealthText);
        }
        if (glassCannonHealth <= 0)
        {
            CharacterDeath(glassCannon, glassCannonDead, glassCannonHealthText);
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
        if (playerDead != true)
        {
            playerHealthText.text = "HP: " + playerHealth.ToString() + " / " + playerHealthMAX.ToString();
        }
        if (glassCannonDead != true)
        {
            glassCannonHealthText.text = "HP: " + glassCannonHealth.ToString() + " / " + glassCannonHealthMAX.ToString();
        }
        if (enemy1Dead != true)
        {
            enemy1HealthText.text = "HP: " + enemy1Health.ToString() + " / " + enemy1HealthMAX.ToString();
        }
    }
}
