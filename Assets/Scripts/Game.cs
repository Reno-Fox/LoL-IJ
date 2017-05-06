using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

[Serializable]
public class Game : MonoBehaviour
{
    public Click clickManager;
    public HeroManager heroManager;
    public ItemManager itemManager;

    public static Game current;

    public Game()
    {
        current = this;
    }
}