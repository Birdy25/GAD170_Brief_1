using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  A <see langword="static"/> class with methods (functions) for initialising or randomising the stats class.
///  
/// TODO:
///     Initialise a stats instance with generated starting stats
///     Handle the assignment of extra points or xp into an existing stats of a character
///         - this is expected to be used by NPCs leveling up to match the player.
/// </summary>
public static class StatsGenerator
{
    public static void InitialStats(Stats stats)
    {
        stats.level = 1;
        try
        {
            stats.level = System.Convert.ToInt32(System.IO.File.ReadAllText("level.txt"));
        }
        catch
        {

        }

        //generates stats on game start
        stats.rhythm = (Random.Range(5, 10));
        stats.style = (Random.Range(5, 10));
        stats.luck = (Random.Range(1, 5));
        /*data.player.rhythm = (Random.Range(5, 10) * stats.level);
        data.player.style = (Random.Range(5, 10) * stats.level);
        data.player.luck = (Random.Range(1, 5) * stats.level);*/
    }

    public static void AssignUnusedPoints(Stats stats, int points)
    {
        double rhythmPoints = points / 2.5;
        double luckPoints = points / 5;
        double stylePoints = points / 2.5;
        Debug.Log(stats.rhythm + " old rythm");
        Debug.Log(stats.style + " old style");
        Debug.Log(stats.luck + " old luck");
        stats.rhythm += System.Convert.ToInt32(rhythmPoints);
        stats.style += System.Convert.ToInt32(stylePoints);
        stats.luck += System.Convert.ToInt32(luckPoints);
        Debug.Log(stats.rhythm + " new rythm");
        Debug.Log(stats.style + " new style");
        Debug.Log(stats.luck + " new luck");
    }
}
