using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Use this for initialization

    [SerializeField] int hitPOints =3;
  
    private List<Waypoint> calculatedPath;

    void Start()
    {
        
        PathFinder pathfinder = FindObjectOfType<PathFinder>();
        
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
        

    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
     
        
        print("Starting patrol..."); 
        foreach (Waypoint waypoint in path)
        {
            transform.localPosition = waypoint.transform.Find("top").position;
            yield return new WaitForSeconds(1f);
        }

       
        print("Ending patrol");
    }

   
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        hitPOints -= 1;
        SendMessage("HitParticles");
        print(hitPOints);
        if (hitPOints == 0)
            Destroy(gameObject);
    }
}
