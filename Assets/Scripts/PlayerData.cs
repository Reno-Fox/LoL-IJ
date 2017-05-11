using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
	// Use this for initialization
	void Start () {
		
	}

    public Text Info;

    public float totalXp;
    public int currentLevel;
    public int xpTillNextLevel;

    public int mana;
    public float gold;

    public void AddExperience(float experienceAmount)
    {
        UpdateXp(experienceAmount);
    }
    public void AddGold(float goldAmount)
    {
        gold += goldAmount;
    }

    void UpdateXp(float experience)
    {
        totalXp = totalXp + experience;
        int currentXp = (int)(0.1f * Math.Sqrt(totalXp));

        if (currentXp != currentLevel)
        {
            currentLevel = currentXp;
            Debug.Log("Leveled up.");
        }

        xpTillNextLevel = 100 * (currentLevel + 1) * (currentLevel + 1);

        Info.text = totalXp + " / " + xpTillNextLevel;
    }
}
