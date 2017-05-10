using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class HeroManager : MonoBehaviour {

    public Game game;
    public Text totalHeroGoldValue;

    public List<Hero> heroes;

    void Start()
    {
        StartCoroutine(AutoTick());
    }

    void Update()
    {
        totalHeroGoldValue.text = GetHeroValue() + "gold/sec";
    }

    public float GetHeroValue()
    {
        float heroValue = 0;
        foreach(Hero hero in heroes)
        {
            heroValue += hero.count * hero.clickRate;
        }
        return heroValue;
    }

    public void AutoGoldPerSecondInterval()
    {
        game.clickManager.totalGold += GetHeroValue() / Settings.AutoGoldPerSecondInterval;
    }

    IEnumerator AutoTick()
    {
        while (true)
        {
            AutoGoldPerSecondInterval();
            yield return new WaitForSeconds(Settings.AutoTickInterval);
        }
    }
}
