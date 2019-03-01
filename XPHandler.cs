using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>
public class XPHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GainXP;
    }

    private void OnDisable()
    {
        GameEvents.OnBattleConclude -= GainXP;
    }

    public void GainXP(BattleResultEventData data)
    {
        //sets xp to zero (does not effect previous file)
        data.player.xp = 0;
        data.player.level = 1;
        //tries to read the xp and level from text file
        try
        {
            data.player.xp = System.Convert.ToInt32(System.IO.File.ReadAllText("xp.txt"));
            data.player.level = System.Convert.ToInt32(System.IO.File.ReadAllText("level.txt"));
        }
        catch
        {

        }

        //adds xp based on win
        if (data.outcome == 1)
        {
            data.player.xp += 20;
            Debug.Log("win");
            Debug.Log(data.player.xp);
        }
        if (data.outcome == 0)
        {
            data.player.xp += 10;
            Debug.Log("lose");
            Debug.Log(data.player.xp);
        }

        //checks level based on total xp
        if (data.player.xp >= 100 && data.player.level < 2)
        {
            data.player.level +=1;
            GameEvents.PlayerLevelUp(data.player.level);
            StatsGenerator.AssignUnusedPoints(data.player, 10);
            Debug.Log("Level Up");
        }
        if (data.player.xp >= 200 && data.player.level < 3)
        {
            data.player.level +=1;
            GameEvents.PlayerLevelUp(data.player.level);
            StatsGenerator.AssignUnusedPoints(data.player, 10);
            Debug.Log("Level Up");
        }
        if (data.player.xp >= 300 && data.player.level < 4)
        {
            data.player.level += 1;
            GameEvents.PlayerLevelUp(data.player.level);
            StatsGenerator.AssignUnusedPoints(data.player, 10);
            Debug.Log("Level Up");
        }
        if (data.player.xp >= 500 && data.player.level < 5)
        {
            data.player.level += 1;
            GameEvents.PlayerLevelUp(data.player.level);
            StatsGenerator.AssignUnusedPoints(data.player, 10);
            Debug.Log("Level Up");
        }
        if (data.player.xp >= 800 && data.player.level < 6)
        {
            data.player.level += 1;
            GameEvents.PlayerLevelUp(data.player.level);
            StatsGenerator.AssignUnusedPoints(data.player, 10);
            Debug.Log("Level Up");
        }
        if (data.player.xp >= 1300 && data.player.level < 7)
        {
            data.player.level += 1;
            GameEvents.PlayerLevelUp(data.player.level);
            StatsGenerator.AssignUnusedPoints(data.player, 10);
            Debug.Log("Level Up");
        }
        if (data.player.xp >= 2100 && data.player.level < 8)
        {
            data.player.level += 1;
            GameEvents.PlayerLevelUp(data.player.level);
            StatsGenerator.AssignUnusedPoints(data.player, 10);
            Debug.Log("Level Up");
        }
        if (data.player.xp >= 3400 && data.player.level < 9)
        {
            data.player.level += 1;
            GameEvents.PlayerLevelUp(data.player.level);
            StatsGenerator.AssignUnusedPoints(data.player, 10);
            Debug.Log("Level Up");
        }
        if (data.player.xp >= 5500 && data.player.level < 10)
        {
            data.player.level += 1;
            GameEvents.PlayerLevelUp(data.player.level);
            StatsGenerator.AssignUnusedPoints(data.player, 10);
            Debug.Log("Level Up");
        }        System.IO.File.WriteAllText("xp.txt", System.Convert.ToString(data.player.xp));
        System.IO.File.WriteAllText("level.txt", System.Convert.ToString(data.player.level));
    }
}

