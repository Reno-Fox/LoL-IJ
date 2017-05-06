using UnityEngine;
using UnityEngine.UI;

public class Hero : MonoBehaviour {

    public Click click;
    public string itemName;
    public Text itemInfo;

    public float baseCost;
    public int count;

    public int clickRate;

    public Color standard;
    public Color affordable;

    void Start()
    {
        count = 0;
    }

    void Update()
    {
        itemInfo.text = itemName + "\nCost " + baseCost + "\nGold: " + clickRate + "/s";

        if (click.totalGold >= baseCost)
        {
            GetComponent<Image>().color = affordable;
        }
        else
        {
            GetComponent<Image>().color = standard;
        }
    }

    public void PurchasedHero()
    {
        if (click.totalGold >= baseCost)
        {
            click.totalGold -= baseCost;
            count += 1;
            baseCost = Mathf.Round(baseCost * Mathf.Pow(Settings.PurchaseIncreaseRate, count));
        }
    }

}
