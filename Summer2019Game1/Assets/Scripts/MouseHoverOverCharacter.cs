using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseHoverOverCharacter : MonoBehaviour
{
    private Animator animator;
    private Combat combatScript;

    private GameObject cMRightSprite;
    private Animator cMRightSpriteAnim;
    private TextMeshProUGUI cMRightCharacterName;
    private TextMeshProUGUI cMRightCharacterHealthText;

    public bool ally1 = false, ally2 = false, ally3 = false, enemy1 = false, enemy2 = false, enemy3 = false;
    private int health;
    private int maxHealth;

    void Awake()
    {
        animator = gameObject.GetComponent<Animator>();
        combatScript = GameObject.FindWithTag("CombatControl").GetComponent<Combat>();
        cMRightSprite = combatScript.cMRightSprite;
        cMRightSpriteAnim = combatScript.cMRightSpriteAnim;
        cMRightCharacterName = combatScript.cMRightCharacterName;
        cMRightCharacterHealthText = combatScript.cMRightCharacterHealthText;
    }

    void Update()
    {
        if (ally1 == true)
        {
            health = combatScript.ally1Health;
            maxHealth = combatScript.ally1MaxHealth;
        }
        if (ally2 == true)
        {
            health = combatScript.ally2Health;
            maxHealth = combatScript.ally2MaxHealth;
        }
        if (ally3 == true)
        {
            health = combatScript.ally3Health;
            maxHealth = combatScript.ally3MaxHealth;
        }
        if (enemy1 == true)
        {
            health = combatScript.enemy1Health;
            maxHealth = combatScript.enemy1MaxHealth;
        }
        if (enemy2 == true)
        {
            health = combatScript.enemy2Health;
            maxHealth = combatScript.enemy2MaxHealth;
        }
        if (enemy3 == true)
        {
            health = combatScript.enemy3Health;
            maxHealth = combatScript.enemy3MaxHealth;
        }
    }
    public void OnMouseOver()
    {
        if (enemy1 == true || enemy2 == true || enemy3 == true)
        {
            if (combatScript.selectAnEnemy == true)
            {
                animator.SetBool("HighlightCharacter", true);
                cMRightCharacterName.text = name;
                cMRightCharacterHealthText.text = "HP: \n" + health.ToString() + " / " + maxHealth.ToString();
                UpdateSprite();
            }
            else
            {
                animator.SetBool("HighlightCharacter", false);
                cMRightCharacterName.text = "";
                cMRightCharacterHealthText.text = "";
                RemoveSprite();
            }
        }

        if (ally1 == true || ally2 == true || ally3 == true)
        {
            if (combatScript.selectAnAlly == true)
            {
                animator.SetBool("HighlightCharacter", true);
                cMRightCharacterName.text = name;
                cMRightCharacterHealthText.text = "HP: \n" + health.ToString() + " / " + maxHealth.ToString();
                UpdateSprite();
            }
            else
            {
                animator.SetBool("HighlightCharacter", false);
                cMRightCharacterName.text = "";
                cMRightCharacterHealthText.text = "";
                RemoveSprite();
            }
        }
    }

    public void OnMouseExit()
    {
        animator.SetBool("HighlightCharacter", false);
        cMRightCharacterName.text = "";
        cMRightCharacterHealthText.text = "";
        RemoveSprite();
    }

    private void UpdateSprite()
    {
        if (name == "Slime1" || name == "Slime2" || name == "Slime3")
        {
            cMRightSpriteAnim.SetBool("RSSlime", true);
            cMRightSpriteAnim.SetBool("RSHeroProtagonist", false);
            cMRightSpriteAnim.SetBool("RSGlassCannon", false);
            cMRightSpriteAnim.SetBool("RSSupportMain", false);
        }
        else if (name == "HeroProtagonist")
        {
            cMRightSpriteAnim.SetBool("RSSlime", false);
            cMRightSpriteAnim.SetBool("RSHeroProtagonist", true);
            cMRightSpriteAnim.SetBool("RSGlassCannon", false);
            cMRightSpriteAnim.SetBool("RSSupportMain", false);
        }
        else if (name == "GlassCannon")
        {
            cMRightSpriteAnim.SetBool("RSSlime", false);
            cMRightSpriteAnim.SetBool("RSHeroProtagonist", false);
            cMRightSpriteAnim.SetBool("RSGlassCannon", true);
            cMRightSpriteAnim.SetBool("RSSupportMain", false);
        }
        else if (name == "SupportMain")
        {
            cMRightSpriteAnim.SetBool("RSSlime", false);
            cMRightSpriteAnim.SetBool("RSHeroProtagonist", false);
            cMRightSpriteAnim.SetBool("RSGlassCannon", false);
            cMRightSpriteAnim.SetBool("RSSupportMain", true);
        }
    }

    private void RemoveSprite()
    {
        cMRightSpriteAnim.SetBool("RSSlime", false);
        cMRightSpriteAnim.SetBool("RSHeroProtagonist", false);
        cMRightSpriteAnim.SetBool("RSGlassCannon", false);
        cMRightSpriteAnim.SetBool("RSSupportMain", false);
    }
}
