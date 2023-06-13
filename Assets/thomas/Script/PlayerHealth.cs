using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    public SliderChanger slider;

    public float health;

    void Start()
    {
        slider.SetMaxValue(maxHealth);
        health = maxHealth;
    }

    void Update()
    {
        slider.SetValue(health);
        if(health <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
