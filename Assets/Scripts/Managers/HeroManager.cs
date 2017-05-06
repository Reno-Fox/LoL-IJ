using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroManager : MonoBehaviour {

    public Click click;
    public Text totalHeroGoldValue;

    public Hero[] heroes;

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
        click.totalGold += GetHeroValue() / Settings.AutoGoldPerSecondInterval;
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
