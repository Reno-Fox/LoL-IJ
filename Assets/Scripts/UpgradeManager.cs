using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpgradeManager : MonoBehaviour {

    public Click click;
    public UnityEngine.UI.Text itemInfo;
    public float cost;
    public int count = 0;
    public int clickPower;
    public string itemName;
    public Color standard;
    public Color affordable;
    private float baseCost;

    void Start()
    {
        baseCost = cost;
    }

    void Update()
    {
        itemInfo.text = itemName + "\nCost: " + cost + "\nPower: " + clickPower;

        if(click.gold >= cost)
        {
            GetComponent<Image>().color = affordable;
        } else
        {
            GetComponent<Image>().color = affordable;
        }
    }
    
    public void PurchaseUpgrade()
    {
        if (click.gold >= cost)
        {
            click.gold -= cost;
            count += 1;
            click.goldPerClick += clickPower;
            cost = Mathf.Round (baseCost * Mathf.Pow(1.15f, count));
        }
    }
}
