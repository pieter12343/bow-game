using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    [SerializeField] float damage = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
              AIHP enemyHealth = other.gameObject.GetComponent<AIHP>();
            enemyHealth.TakeDamage(damage);
        }
    }
}
