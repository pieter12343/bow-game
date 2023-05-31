using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public float zMin;
    public float zMax;

    public GameObject enemy;
    public Transform prefab;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax)), Quaternion.identity);
            yield return new WaitForSeconds(1);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
