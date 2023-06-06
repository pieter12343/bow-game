using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHP : MonoBehaviour
{
    public int MaxHealth = 1;
    public int currentHealth;


    void Start()
    {
        currentHealth = MaxHealth;
    }


    void takeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
