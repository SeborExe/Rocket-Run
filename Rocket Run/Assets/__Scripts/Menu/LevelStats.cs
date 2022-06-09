using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelStats
{
    private const string Highest_Level = "highest_level";

    public static int GetHighestLevel()
    {
        return PlayerPrefs.GetInt(Highest_Level, 0);
    }

    public static void SetHighestLevel(int level)
    {
        PlayerPrefs.SetInt(Highest_Level, level);
    }
}
