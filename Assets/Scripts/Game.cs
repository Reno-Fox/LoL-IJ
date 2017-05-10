using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Game : MonoBehaviour
{
    public static Game Instance;

    public ClickManager clickManager;
    public HeroManager heroManager;
    public ItemManager itemManager;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(Instance);
            Instance = this;
        }
        else if (Instance != this)
        {   
            Destroy(gameObject);
        }
    }
}