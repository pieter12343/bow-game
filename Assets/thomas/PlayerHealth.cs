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

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Enemy"))
        {
            health = health - 25;
        }
    }
}
