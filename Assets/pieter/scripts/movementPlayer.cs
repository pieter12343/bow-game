using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movementPlayer : MonoBehaviour
{
    public static Vector3 playerPos;
    public float gravity = -9.81f;
    public float health = 100f;
    float amount;

    public void Start()
    {
        StartCoroutine(TrackPlayer());
    }

    IEnumerator TrackPlayer()
    {
        while (true)
        {
            playerPos = gameObject.transform.position;
            yield return null;
        }
    }

    public void TakeDamage()
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }

    }
    void Die()
    {
        SceneManager.LoadScene(0);
    }
}