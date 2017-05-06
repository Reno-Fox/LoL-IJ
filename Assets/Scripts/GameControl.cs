using System;
using System.Collections;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public float goldPerSecond;
    public float goldPerClick;
    public float totalGold;

    public void Start()
    {
        
    }

    // Use this for initialization
    void Awake () {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
	}
	
    //Save user data
    public void Save()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        //Get path where we want to save our files
        FileStream stream = File.Create(Application.persistentDataPath + "/playerInfo.dat");

        //Pass saved data to Serializable Class
        PlayerData playerData = new PlayerData();
        playerData.goldPerSecond = goldPerSecond;
        playerData.goldPerClick = goldPerClick;
        playerData.totalGold = totalGold;

        formatter.Serialize(stream, playerData);
        stream.Close();
    }

    //Load user data
    public void Load()
    {
        //Checks to see if file exists
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData playerData = (PlayerData)formatter.Deserialize(stream);
            stream.Close();

            goldPerSecond = playerData.goldPerSecond;
            goldPerClick = playerData.goldPerClick;
            totalGold = playerData.totalGold;
        }
    }
}

[Serializable]
class PlayerData
{
    public float goldPerSecond;
    public float goldPerClick;
    public float totalGold;
}
