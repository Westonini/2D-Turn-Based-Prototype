using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseHoverOverCharacter : MonoBehaviour
{
    private Animator animator;
    private DecisionPhase dP;

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
        dP = GameObject.FindWithTag("CombatControl").GetComponent<DecisionPhase>();

        cMRightSprite = dP.cMRightSprite;
        cMRightSpriteAnim = dP.cMRightSpriteAnim;
        cMRightCharacterName = dP.cMRightCharacterName;
        cMRightCharacterHealthText = dP.cMRightCharacterHealthText;
    }

    void Update() //Always keep the health and maxHealth updated.
    {
        if (ally1 == true)
        {
            health = dP.ally1Health;
            maxHealth = dP.ally1MaxHealth;
        }
        if (ally2 == true)
        {
            health = dP.ally2Health;
            maxHealth = dP.ally2MaxHealth;
        }
        if (ally3 == true)
        {
            health = dP.ally3Health;
            maxHealth = dP.ally3MaxHealth;
        }
        if (enemy1 == true)
        {
            health = dP.enemy1Health;
            maxHealth = dP.enemy1MaxHealth;
        }
        if (enemy2 == true)
        {
            health = dP.enemy2Health;
            maxHealth = dP.enemy2MaxHealth;
        }
        if (enemy3 == true)
        {
            health = dP.enemy3Health;
            maxHealth = dP.enemy3MaxHealth;
        }
    }
    public void OnMouseOver()
    {
        if (enemy1 == true || enemy2 == true || enemy3 == true) //If the mouse is hovering over enemy1, enemy2, or enemy3...
        {
            if (dP.selectAnEnemy == true && dP.selectAllTargets == false) //and if selectAnEnemy is true while selectAllTargets is false, highlight the character when the mouse is hovering over them and show their info in the bottom right corner.
            {
                animator.SetBool("HighlightCharacter", true);
                cMRightCharacterName.text = name;
                cMRightCharacterHealthText.text = "HP: \n" + health.ToString() + " / " + maxHealth.ToString();
                UpdateSprite();
            }
            else if (dP.selectAnEnemy == true && dP.selectAllTargets == true) //and if selectAnEnemy and selectAllTargets are true, highlight all the characters when the mouse is hovering over them and show their info in the bottom right corner.
            {
                dP.enemy1Anim.SetBool("HighlightCharacter", true);
                dP.enemy2Anim.SetBool("HighlightCharacter", true);
                dP.enemy3Anim.SetBool("HighlightCharacter", true);
                cMRightCharacterName.text = "All Enemies";
                cMRightCharacterHealthText.text = "HP: \n" + (dP.enemy1Health + dP.enemy2Health + dP.enemy3Health).ToString() + " / " + (dP.enemy1MaxHealth + dP.enemy2MaxHealth + dP.enemy3MaxHealth).ToString();
                UpdateSprite();
            }
            else //else reset everything
            {
                dP.enemy1Anim.SetBool("HighlightCharacter", false);
                dP.enemy2Anim.SetBool("HighlightCharacter", false);
                dP.enemy3Anim.SetBool("HighlightCharacter", false);
                animator.SetBool("HighlightCharacter", false);
                cMRightCharacterName.text = "";
                cMRightCharacterHealthText.text = "";
                RemoveSprite();
            }
        }

        if (ally1 == true || ally2 == true || ally3 == true) //If the mouse is hovering over ally1, ally2, or ally3...
        {
            if (dP.selectAnAlly == true && dP.selectAllTargets == false) //and if selectAnAlly is true while selectAllTargets is false, highlight the character when the mouse is hovering over them and show their info in the bottom right corner.
            {
                animator.SetBool("HighlightCharacter", true);
                cMRightCharacterName.text = name;
                cMRightCharacterHealthText.text = "HP: \n" + health.ToString() + " / " + maxHealth.ToString();
                UpdateSprite();
            }
            else if (dP.selectAnAlly == true && dP.selectAllTargets == true) //and if selectAnAlly and selectAllTargets are true, highlight all the characters when the mouse is hovering over them and show their info in the bottom right corner.
            {
                dP.ally1Anim.SetBool("HighlightCharacter", true);
                dP.ally2Anim.SetBool("HighlightCharacter", true);
                dP.ally3Anim.SetBool("HighlightCharacter", true);
                cMRightCharacterName.text = "All Allies";
                cMRightCharacterHealthText.text = "HP: \n" + (dP.ally1Health + dP.ally2Health + dP.ally3Health).ToString() + " / " + (dP.ally1MaxHealth + dP.ally2MaxHealth + dP.ally3MaxHealth).ToString();
                UpdateSprite();
            }
            else //else reset everything
            {
                dP.ally1Anim.SetBool("HighlightCharacter", false);
                dP.ally2Anim.SetBool("HighlightCharacter", false);
                dP.ally3Anim.SetBool("HighlightCharacter", false);
                animator.SetBool("HighlightCharacter", false);
                cMRightCharacterName.text = "";
                cMRightCharacterHealthText.text = "";
                RemoveSprite();
            }
        }
    }

    public void OnMouseExit() //When the mouse stops hovering over the characters, reset everything.
    {
        dP.ally1Anim.SetBool("HighlightCharacter", false);
        dP.ally2Anim.SetBool("HighlightCharacter", false);
        dP.ally3Anim.SetBool("HighlightCharacter", false);
        dP.enemy1Anim.SetBool("HighlightCharacter", false);
        dP.enemy2Anim.SetBool("HighlightCharacter", false);
        dP.enemy3Anim.SetBool("HighlightCharacter", false);
        animator.SetBool("HighlightCharacter", false);
        cMRightCharacterName.text = "";
        cMRightCharacterHealthText.text = "";
        RemoveSprite();
    }

    private void UpdateSprite() //Updates which sprite is shown on the bottom left corner.
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

    private void OnMouseEnter() //Used to make a sound when the mouse goes over a character.
    {
        if ((enemy1 == true || enemy2 == true || enemy3 == true) && dP.selectAnEnemy == true)
        {
            FindObjectOfType<AudioManager>().Play("HighlightedLower");
        }
        if ((ally1 == true || ally2 == true || ally3 == true) && dP.selectAnAlly == true)
        {
            FindObjectOfType<AudioManager>().Play("HighlightedLower");
        }
    }
}
