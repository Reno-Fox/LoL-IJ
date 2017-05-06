using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public Click click;
    public string itemName;
    public Text itemInfo;

    private float goldCost;
    public float goldCostMultiplier;
    public int count;

    public int clickRate;

    public Color standard;
    public Color affordable;

    void Start()
    {
        count = 0;
        goldCost = goldCostMultiplier;
    }

    void Update()
    {
        itemInfo.text = itemName + "\nCost: " + goldCostMultiplier + "\n" + clickRate + "/gold click";

        if (click.totalGold >= goldCostMultiplier)
        {
            GetComponent<Image>().color = affordable;
        }
        else
        {
            GetComponent<Image>().color = standard;
        }
    }

    public void PurchaseItem()
    {
        if (click.totalGold >= goldCostMultiplier)
        {
            click.totalGold -= goldCostMultiplier;
            count += 1;
            click.totalGoldPerClick += clickRate;
            goldCostMultiplier = Mathf.Round(goldCost * Mathf.Pow(Settings.PurchaseIncreaseRate, count));
        }
    }
}
