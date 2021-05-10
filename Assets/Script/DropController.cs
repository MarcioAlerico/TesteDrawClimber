using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
           Destroy(baseCube);
       }
                
    }
}
