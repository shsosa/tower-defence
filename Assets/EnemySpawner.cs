using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemy;

    [SerializeField] private Transform spawnPoint;
   
    void Start()
    {
        StartCoroutine(Spawn());
    }

  

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(2f);
        }
       
    }
}
