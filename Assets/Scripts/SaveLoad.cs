using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

[Serializable]
public class SaveLoad : MonoBehaviour
{
    private string SaveLocation
    {
        get { return Application.persistentDataPath + "/savedGames.lol"; }
    }

    public void Save()
    {
        BinaryFormatter format = new BinaryFormatter();
        FileStream file = File.Create(SaveLocation);

        SaveState save = new SaveState();

        save.TotalGold = Game.Instance.clickManager.totalGold;
        save.TotalGoldPerClick = Game.Instance.clickManager.totalGoldPerClick;

        foreach(Item i in Game.Instance.itemManager.items)
        {
            ItemSaveState item = new ItemSaveState();
            item.GoldCostMultiplier = i.goldCostMultiplier;
            item.GoldCost = i.goldCost;
            item.Count = i.count;

            save.Items.Add(item);
        }

        foreach (Hero h in Game.Instance.heroManager.heroes)
        {
            HeroSaveState hero = new HeroSaveState();
            hero.GoldCost = h.goldCost;
            hero.Count = h.count;
            hero.ClickRate = h.clickRate;

            save.Heroes.Add(hero);
        }

        format.Serialize(file, save);
        file.Close();

        Debug.Log("Game Saved.");
    }

    public void Load()
    {
        if (File.Exists(SaveLocation))
        {
            BinaryFormatter format = new BinaryFormatter();
            FileStream file = File.Open(SaveLocation, FileMode.Open);

            SaveState save = (SaveState)format.Deserialize(file);
            file.Close();

            Game.Instance.clickManager.totalGold = save.TotalGold;
            Game.Instance.clickManager.totalGoldPerClick = save.TotalGoldPerClick;

            Game.Instance.itemManager.items.Clear();
            foreach (ItemSaveState i in save.Items)
            {
                Item item = new global::Item();
                item.goldCostMultiplier = i.GoldCostMultiplier;
                item.goldCost = i.GoldCost;
                item.count = i.Count;

                Game.Instance.itemManager.items.Add(item);
            }

            Game.Instance.heroManager.heroes.Clear();
            foreach (HeroSaveState i in save.Heroes)
            {
                Hero hero = new Hero();
                hero.goldCost = i.GoldCost;
                hero.count = i.Count;
                hero.clickRate = i.ClickRate;

                Game.Instance.heroManager.heroes.Add(hero);
            }

            Debug.Log("Game Load. ");
        }
        else
        {
            Debug.Log("File does not exist.");
        }
    }
}

[Serializable]
class SaveState
{
    public float TotalGold = 0;
    public float TotalGoldPerClick = 0;
    [SerializeField]
    public List<ItemSaveState> Items = new List<ItemSaveState>();
    [SerializeField]
    public List<HeroSaveState> Heroes = new List<HeroSaveState>();
}

[Serializable]
class HeroSaveState
{
    public float GoldCost;
    public int Count;
    public int ClickRate;
}

[Serializable]
class ItemSaveState
{
    public float GoldCost;
    public float GoldCostMultiplier;
    public int Count;
}
