using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamage : MonoBehaviour
{
    float damage = 10f;
    PlayerHealth playerHealth;
    bool isDamaging = true;
    
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && isDamaging)
        {
            playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damage);
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        isDamaging = false;
        yield return new WaitForSeconds(1);
        isDamaging = true;
    }
}
