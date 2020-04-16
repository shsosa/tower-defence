using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

public class Waypoint : MonoBehaviour
{
   
    // public ok here as is a data class
    public bool isExplored = false;
    public bool isPlaceble = true;
    public Waypoint exploredFrom;

   

  

    Vector2Int gridPos;

    const int gridSize = 10;

    public int GetGridSize()
    {
        return gridSize;
    }
	
    // consider setting own color in Update()

    public Vector2Int GetGridPos()
    {
        var position = transform.position;
        return new Vector2Int(
            Mathf.RoundToInt(position.x ),
            Mathf.RoundToInt(position.z )
        );
    }

  
    
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlaceble)
            {
                
               FindObjectOfType<TowerFactory>().AddTower(this);
                print("tower is placeble");
            }
            else print("is not placeble");
            
            print ("clicked " + gameObject.name);
        }//left click
        
    }

   
}

