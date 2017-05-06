using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {

    public Click click;
    public string itemName;
    public Text itemInfo;

    private float baseCost;
    public float newCost;
    public int count;

    public int clickRate;

    public Color standard;
    public Color affordable;

    void Start()
    {
        count = 0;
        baseCost = newCost;
    }

    void Update()
    {
        itemInfo.text = itemName + "\nCost: " + newCost + "\nPower: " + clickRate;

        if (click.totalGold >= newCost)
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
        if (click.totalGold >= newCost)
        {
            click.totalGold -= newCost;
            count += 1;
            click.totalGoldPerClick += clickRate;
            newCost = Mathf.Round(baseCost * Mathf.Pow(Settings.PurchaseIncreaseRate, count));
        }
    }
}
