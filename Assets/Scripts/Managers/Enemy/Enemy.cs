using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    public GameObject prefab;

    public string Name;
    public Text Info;

    public bool isAlive;
    public bool isDead;
    public float currentHealth;
    public float maxHealth;
    public float experience;

    public float coinsDroped;

    public bool enableTimer;
    public float timeToKill;

    void Start()
    {
    }

    void Update()
    { 
    }

    public void DropCoins()
    {
    }

}
