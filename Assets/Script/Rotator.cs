using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Make the legs rotate.
/// </summary>
public class Rotator : MonoBehaviour
{
    //Set player Speed
    public float speed = 120f;
   
    // Update is called once per frame
    void Update()
    {
     // Rotate the player legs
     transform.Rotate(Vector3.down * speed * Time.deltaTime);  
       
    }
}
