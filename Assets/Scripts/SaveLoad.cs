using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

public class SaveLoad : MonoBehaviour
{
    public Game savedGames;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
    //it's static so we can call it from anywhere
    public void Save()
    {
        savedGames = Game.current;
        BinaryFormatter bf = new BinaryFormatter();
        //Application.persistentDataPath is a string, so if you wanted you can put that into debug.log if you want to know where save games are located
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd"); //you can call it anything you want
        bf.Serialize(file, savedGames);
        file.Close();
        Debug.Log("Save Completed");
        Debug.Log(Application.persistentDataPath + " / savedGames.gd");
    }

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            savedGames = (Game)bf.Deserialize(file);
            file.Close();
        }
        Debug.Log("Load Completed");
        Debug.Log(Application.persistentDataPath + " / savedGames.gd");
    }
}