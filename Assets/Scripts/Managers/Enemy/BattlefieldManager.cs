using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class BattlefieldManager : MonoBehaviour
{
    public PlayerData playerData;
    public List<Enemy> enemys;
    public int currentIndex;
    public bool activeEnemy;

    private void Start()
    {
        for (int i = 0; i < enemys.Count(); i++)
        {
            Enemy currentEnemy = enemys[i];
            enemys[i].prefab.name = currentEnemy.name + i.ToString();
            currentEnemy.currentHealth = currentEnemy.maxHealth;
            currentEnemy.isAlive = true;
            currentEnemy.isDead = false;
        }
    }

    public void AttackEnemy(float damage)
    {
        if (currentIndex < enemys.Count())
        {
            Enemy currentEnemy = enemys[currentIndex];
            currentEnemy.currentHealth -= damage; //hardcode change

            if (currentEnemy.isAlive == true && currentEnemy.currentHealth <= 0)
            {
                playerData.AddExperience(currentEnemy.experience);
                playerData.AddGold(currentEnemy.coinsDroped);

                currentEnemy.isDead = true;
                currentIndex++;
            }
        }
    }
}
