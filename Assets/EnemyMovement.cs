using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Use this for initialization

   
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

   
   
}
