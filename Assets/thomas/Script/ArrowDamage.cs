using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDamage : MonoBehaviour
{
    [SerializeField] int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
              AIHP enemyHealth = other.gameObject.GetComponent<AIHP>();
            enemyHealth.takeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
