using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIHP : MonoBehaviour
{
    public int MaxHealth = 1;
    public int currentHealth;
    public GameObject particle;

    void Start()
    {
        currentHealth = MaxHealth;
    }
    private void Update()
    {
        if (currentHealth <= 0)
        {
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    public void takeDamage(int amount)
    {
        currentHealth -= amount;
    }
    
}
