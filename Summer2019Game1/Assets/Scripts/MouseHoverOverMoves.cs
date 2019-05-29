using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHoverOverMoves : MonoBehaviour
{
    private DecisionPhase dP;

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
        dP = GameObject.FindWithTag("CombatControl").GetComponent<DecisionPhase>();
    }

    public void OnMouseHover()
    {
        if (dP.characterTurn == "HeroProtagonist") //If it's HeroProtagonist's turn, show all of his move info when hovering over each move with the mouse.
        {
            if (buttonIsMove1 == true)
            {
                dP.cMMoveInfo.text = move1HeroProtagonistInfo;
            }
            else if (buttonIsMove2 == true)
            {
                dP.cMMoveInfo.text = move2HeroProtagonistInfo;
            }
            else if (buttonIsMove3 == true)
            {
                dP.cMMoveInfo.text = move3HeroProtagonistInfo;
            }
            else if (buttonIsMove4 == true)
            {
                dP.cMMoveInfo.text = move4HeroProtagonistInfo;
            }
        }
        else if (dP.characterTurn == "GlassCannon") //If it's GlassCannon's turn, show all of his move info when hovering over each move with the mouse.
        {
            if (buttonIsMove1 == true)
            {
                dP.cMMoveInfo.text = move1GlassCannonInfo;
            }
            else if (buttonIsMove2 == true)
            {
                dP.cMMoveInfo.text = move2GlassCannonInfo;
            }
            else if (buttonIsMove3 == true)
            {
                dP.cMMoveInfo.text = move3GlassCannonInfo;
            }
            else if (buttonIsMove4 == true)
            {
                dP.cMMoveInfo.text = move4GlassCannonInfo;
            }
        }
        else if (dP.characterTurn == "SupportMain") //If it's SupportMain's turn, show all of their move info when hovering over each move with the mouse.
        {
            if (buttonIsMove1 == true)
            {
                dP.cMMoveInfo.text = move1SupportMainInfo;
            }
            else if (buttonIsMove2 == true)
            {
                dP.cMMoveInfo.text = move2SupportMainInfo;
            }
            else if (buttonIsMove3 == true)
            {
                dP.cMMoveInfo.text = move3SupportMainInfo;
            }
            else if (buttonIsMove4 == true)
            {
                dP.cMMoveInfo.text = move4SupportMainInfo;
            }
        }

        if (buttonIsDefend == true) //All characters have the defend move so show the defend move info when hovering over it with the mouse.
        {
            dP.cMMoveInfo.text = defendInfo;
        }
    }
    public void OnMouseExit() //If the mouse stops hoving over the move, make the string empty.
    {
        dP.cMMoveInfo.text = "";
    }

    public void OnMouseClick() //When you click one of the buttons in the CombatMenu it'll play a click sound.
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
    }
}
