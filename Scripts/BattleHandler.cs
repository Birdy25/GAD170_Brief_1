using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class with method (function) to determine the outcome of a dance battle based on the player and NPC that are 
///     dancing off against each other.
///     
/// TODO:
///     Battle needs to use stats and random to determine the winner of the dance off
///       - outcome value to be a float value between 1 and negative 1. 1 being the biggest possible player win over NPC, 
///         through to -1 being the most decimating defeat of the player possible.
/// </summary>
public static class BattleHandler
{
    public static void Battle(BattleEventData data)
    {
        //This needs to be replaced with some actual battle logic, at present 
        // we just award the maximum possible win to the player
        float outcome = 1;        
        var results = new BattleResultEventData(data.player, data.npc, outcome);

        //Luck is randomised every battle
        int roundsLuckStat = (Random.Range(1, 101));
        Debug.Log(roundsLuckStat);

        //checks level

        //battlescore assigned and compared
        int npcBattleScore = data.npc.rhythm + data.npc.style;
        int pcBattleScore = data.player.rhythm + data.player.style;
        Debug.Log("pc" + pcBattleScore);
        Debug.Log("npc" + npcBattleScore);
        //check for luck
        if (data.npc.luck >= roundsLuckStat)
        {
            npcBattleScore = npcBattleScore * data.npc.luck;
        }
        if (data.player.luck >= roundsLuckStat)
        {
            pcBattleScore = pcBattleScore * data.player.luck;
        }

        //check for win
        if (pcBattleScore > npcBattleScore)
        {
            outcome = 1;
        }
        if (npcBattleScore > pcBattleScore)
        {
            outcome = 0;
        }     
        GameEvents.FinishedBattle(results);
    }
}
