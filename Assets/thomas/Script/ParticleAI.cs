using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAI : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(enumerator());
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
