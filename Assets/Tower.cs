using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] private Transform objectToPan;
    [SerializeField] private Transform targetEnemy;
    [SerializeField] private   EnemyMovement[] numberOfEnemies;
    private ParticleSystem bullets;
   
    void Start()
    {
        bullets = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
       
       
        CheckNumberOfEnemies();
    }

    void CheckDistance()
    {
        int dist =Mathf.RoundToInt(Vector3.Distance(targetEnemy.position, transform.position));
        print(dist);
        if (dist == 1)
        {
            objectToPan.LookAt(targetEnemy);
            
           Shoot(true);
        }else Shoot(false); 
    }

    private void Shoot(bool isActive)
    {
        var emmisionMod = bullets.emission;
        emmisionMod.enabled = isActive;
        print(emmisionMod);
    }

    void CheckNumberOfEnemies()
    {
        numberOfEnemies = FindObjectsOfType<EnemyMovement>();
        if (numberOfEnemies.Length > 0)
        {
            CheckDistance();
        }
        else
        {
            Shoot(false);
        }
        print(numberOfEnemies);
    }
}
