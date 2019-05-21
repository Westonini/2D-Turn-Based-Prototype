using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverOverMoves : MonoBehaviour
{
    private Combat combatScript;

    public bool buttonIsMove1 = false;
    public bool buttonIsMove2 = false;
    public bool buttonIsMove3 = false;
    public bool buttonIsMove4 = false;
    public bool buttonIsDefend = false;

    private string defendInfo = "Receive less incoming damage for 1 turn.";

    private string move1HeroProtagonistInfo = "Single-target sword slash attack.";
    private string move2HeroProtagonistInfo = "Buffs damage of 1 ally for 1 turn.";
    private string move3HeroProtagonistInfo = "Sweeping sword attack that damages all enemies.";
    private string move4HeroProtagonistInfo = "Small heal for 1 ally.";

    private string move1GlassCannonInfo = "Single-target shot from his glass cannon. Low chance to cause bleed.";
    private string move2GlassCannonInfo = "Unloads barrage of glass shards which damages all enemies. Very low chance to cause bleed.";
    private string move3GlassCannonInfo = "Heavy-hitting single-target shot that requires 1 turn to charge. Average chance to cause bleed.";
    private string move4GlassCannonInfo = "Can smoke bomb 1 ally; all incoming attacks on that ally have a lower accuracy.";

    private string move1SupportMainInfo = "Average heal for 1 ally.";
    private string move2SupportMainInfo = "Small defense increase for all allies for 1 turn";
    private string move3SupportMainInfo = "Damage single opponent and gain health equal to half of the damage dealt.";
    private string move4SupportMainInfo = "Small heal for all allies.";

    void Awake()
    {
        combatScript = GameObject.FindWithTag("CombatControl").GetComponent<Combat>();
    }

    public void OnMouseOver()
    {
        if (combatScript.characterTurn == "HeroProtagonist")
        {
            if (buttonIsMove1 == true)
            {
                combatScript.cMMoveInfo.text = move1HeroProtagonistInfo;
            }
            else if (buttonIsMove2 == true)
            {
                combatScript.cMMoveInfo.text = move2HeroProtagonistInfo;
            }
            else if (buttonIsMove3 == true)
            {
                combatScript.cMMoveInfo.text = move3HeroProtagonistInfo;
            }
            else if (buttonIsMove4 == true)
            {
                combatScript.cMMoveInfo.text = move4HeroProtagonistInfo;
            }
        }
        else if (combatScript.characterTurn == "GlassCannon")
        {
            if (buttonIsMove1 == true)
            {
                combatScript.cMMoveInfo.text = move1GlassCannonInfo;
            }
            else if (buttonIsMove2 == true)
            {
                combatScript.cMMoveInfo.text = move2GlassCannonInfo;
            }
            else if (buttonIsMove3 == true)
            {
                combatScript.cMMoveInfo.text = move3GlassCannonInfo;
            }
            else if (buttonIsMove4 == true)
            {
                combatScript.cMMoveInfo.text = move4GlassCannonInfo;
            }
        }
        else if (combatScript.characterTurn == "SupportMain")
        {
            if (buttonIsMove1 == true)
            {
                combatScript.cMMoveInfo.text = move1SupportMainInfo;
            }
            else if (buttonIsMove2 == true)
            {
                combatScript.cMMoveInfo.text = move2SupportMainInfo;
            }
            else if (buttonIsMove3 == true)
            {
                combatScript.cMMoveInfo.text = move3SupportMainInfo;
            }
            else if (buttonIsMove4 == true)
            {
                combatScript.cMMoveInfo.text = move4SupportMainInfo;
            }
        }

        if (buttonIsDefend == true)
        {
            combatScript.cMMoveInfo.text = defendInfo;
        }
    }
    public void OnMouseExit()
    {
        combatScript.cMMoveInfo.text = "";
    }
}
