using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public float totalXp;
    public int currentLevel;
    public int xpTillNextLevel;

    void Update()
    {
        UpdateXp(1);
    }

    void UpdateXp(float experience)
    {
        totalXp = totalXp + experience;
        int currentXp = (int)(0.1f * Math.Sqrt(totalXp));

        if(currentXp != currentLevel)
        {
            currentLevel = currentXp;
            Debug.Log("Leveled up.");
        }

        xpTillNextLevel = 100 * (currentLevel + 1) * (currentLevel + 1);
    }
}
