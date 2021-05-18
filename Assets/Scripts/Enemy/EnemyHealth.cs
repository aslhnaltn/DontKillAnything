using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int startHealth = 2;
    Enemy enemy;
    private int currentHealth;
    bool isFoe = true;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        currentHealth = startHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isFoe)
        {
            currentHealth -= damage;
            if (currentHealth <= 0)
            {
                isFoe = false;
                EnemyDie();
            }
        }
    }

    private void EnemyDie()
    {
        enemy.TurnFriendly();
    }
    
}
