using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] private Tower towerPrefab;

    [SerializeField] private int towerLimits = 5;

    Queue<Tower> towerQueue = new Queue<Tower>();
    
   
    public void AddTower(Waypoint baseWaypoint)
    {
        if (towerQueue.Count < towerLimits)
        {
            InstantiateNewTower(baseWaypoint);
            print("queue " + towerQueue.Count);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
            print("queue " + towerQueue.Count);
        }
    }
    
    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.Find("top").position, Quaternion.identity);
        newTower.baseWaypoint = baseWaypoint;
        towerQueue.Enqueue(newTower);
        baseWaypoint.isPlaceble = false;
    }

    private  void MoveExistingTower(Waypoint newBaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();
        
        oldTower.baseWaypoint.isPlaceble = true;
        newBaseWaypoint.isPlaceble = false;

        oldTower.transform.position = newBaseWaypoint.transform.Find("top").position;
        
        oldTower.baseWaypoint = newBaseWaypoint;
        
        towerQueue.Enqueue(oldTower);
    }

   
}
