using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// drop cubes when playes enter the area
/// </summary>
public class DropController : MonoBehaviour
{
    //stores the base that holds the objects that will fall on the player
    public GameObject baseCube;

    //called when something enters the area
    private void OnTriggerEnter(Collider other)
    {
        //Checks if the player who entered the area was the player
       if(other.tag == "Player")
       {
            // destroy the holder to drop the cubes
           Destroy(baseCube);
       }
                
    }
}
