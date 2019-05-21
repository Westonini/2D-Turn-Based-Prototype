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

    void Update() //Always keep the health and maxHealth updated.
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
        if (enemy1 == true || enemy2 == true || enemy3 == true) //If the mouse is hovering over enemy1, enemy2, or enemy3...
        {
            if (combatScript.selectAnEnemy == true && combatScript.selectAllTargets == false) //and if selectAnEnemy is true while selectAllTargets is false, highlight the character when the mouse is hovering over them and show their info in the bottom right corner.
            {
                animator.SetBool("HighlightCharacter", true);
                cMRightCharacterName.text = name;
                cMRightCharacterHealthText.text = "HP: \n" + health.ToString() + " / " + maxHealth.ToString();
                UpdateSprite();
            }
            else if (combatScript.selectAnEnemy == true && combatScript.selectAllTargets == true) //and if selectAnEnemy and selectAllTargets are true, highlight all the characters when the mouse is hovering over them and show their info in the bottom right corner.
            {
                combatScript.enemy1Anim.SetBool("HighlightCharacter", true);
                combatScript.enemy2Anim.SetBool("HighlightCharacter", true);
                combatScript.enemy3Anim.SetBool("HighlightCharacter", true);
                cMRightCharacterName.text = "All Enemies";
                cMRightCharacterHealthText.text = "HP: \n" + (combatScript.enemy1Health + combatScript.enemy2Health + combatScript.enemy3Health).ToString() + " / " + (combatScript.enemy1MaxHealth + combatScript.enemy2MaxHealth + combatScript.enemy3MaxHealth).ToString();
                UpdateSprite();
            }
            else //else reset everything
            {
                combatScript.enemy1Anim.SetBool("HighlightCharacter", false);
                combatScript.enemy2Anim.SetBool("HighlightCharacter", false);
                combatScript.enemy3Anim.SetBool("HighlightCharacter", false);
                animator.SetBool("HighlightCharacter", false);
                cMRightCharacterName.text = "";
                cMRightCharacterHealthText.text = "";
                RemoveSprite();
            }
        }

        if (ally1 == true || ally2 == true || ally3 == true) //If the mouse is hovering over ally1, ally2, or ally3...
        {
            if (combatScript.selectAnAlly == true && combatScript.selectAllTargets == false) //and if selectAnAlly is true while selectAllTargets is false, highlight the character when the mouse is hovering over them and show their info in the bottom right corner.
            {
                animator.SetBool("HighlightCharacter", true);
                cMRightCharacterName.text = name;
                cMRightCharacterHealthText.text = "HP: \n" + health.ToString() + " / " + maxHealth.ToString();
                UpdateSprite();
            }
            else if (combatScript.selectAnAlly == true && combatScript.selectAllTargets == true) //and if selectAnAlly and selectAllTargets are true, highlight all the characters when the mouse is hovering over them and show their info in the bottom right corner.
            {
                combatScript.ally1Anim.SetBool("HighlightCharacter", true);
                combatScript.ally2Anim.SetBool("HighlightCharacter", true);
                combatScript.ally3Anim.SetBool("HighlightCharacter", true);
                cMRightCharacterName.text = "All Allies";
                cMRightCharacterHealthText.text = "HP: \n" + (combatScript.ally1Health + combatScript.ally2Health + combatScript.ally3Health).ToString() + " / " + (combatScript.ally1MaxHealth + combatScript.ally2MaxHealth + combatScript.ally3MaxHealth).ToString();
                UpdateSprite();
            }
            else //else reset everything
            {
                combatScript.ally1Anim.SetBool("HighlightCharacter", false);
                combatScript.ally2Anim.SetBool("HighlightCharacter", false);
                combatScript.ally3Anim.SetBool("HighlightCharacter", false);
                animator.SetBool("HighlightCharacter", false);
                cMRightCharacterName.text = "";
                cMRightCharacterHealthText.text = "";
                RemoveSprite();
            }
        }
    }

    public void OnMouseExit() //When the mouse stops hovering over the characters, reset everything.
    {
        combatScript.ally1Anim.SetBool("HighlightCharacter", false);
        combatScript.ally2Anim.SetBool("HighlightCharacter", false);
        combatScript.ally3Anim.SetBool("HighlightCharacter", false);
        combatScript.enemy1Anim.SetBool("HighlightCharacter", false);
        combatScript.enemy2Anim.SetBool("HighlightCharacter", false);
        combatScript.enemy3Anim.SetBool("HighlightCharacter", false);
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
}
