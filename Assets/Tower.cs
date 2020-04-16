using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    //parameters
    [SerializeField] private Transform objectToPan;
    
    private ParticleSystem bullets;
    public Waypoint baseWaypoint;
   
    //state
   
    void Start()
    {
        bullets = GetComponentInChildren<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
       
       
        CheckNumberOfEnemies();
    }

    void CheckDistance(Transform closestEnemy)
    {
        int dist =Mathf.RoundToInt(Vector3.Distance(closestEnemy.position, transform.position));
        
        if (dist == 1)
        {
            objectToPan.LookAt(closestEnemy);
            
           Shoot(true);
        }else Shoot(false); 
    }

    private void Shoot(bool isActive)
    {
        var emmisionMod = bullets.emission;
        emmisionMod.enabled = isActive;
       
    }

    void CheckNumberOfEnemies()
    {
       var numberOfEnemies = FindObjectsOfType<EnemyMovement>();
        SetTargetEnemy(numberOfEnemies);
      
       
    }

    void SetTargetEnemy(EnemyMovement[] seneEnemies)
    {
        Transform closestEnemy = seneEnemies[0].transform;

        foreach (var testEnemy in seneEnemies)
        {
            closestEnemy = GetClosestEnemy(closestEnemy, testEnemy.transform);
        }
        
        CheckDistance(closestEnemy);
        
       
    }

    private Transform GetClosestEnemy(Transform closestEnemy, Transform testEnemy)
    {
        int closestEnemyDist = Mathf.RoundToInt(Vector3.Distance(closestEnemy.position, transform.position));
        int testEnemtDist = Mathf.RoundToInt(Vector3.Distance(testEnemy.position, transform.position));
        if (closestEnemyDist > testEnemtDist)
            return testEnemy;
        
        return closestEnemy;
        
    }
}
