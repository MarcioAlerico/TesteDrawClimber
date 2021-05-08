using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float speed = 120f;
   
    // Update is called once per frame
    void Update()
    {
     // Rotate the player legs
     transform.Rotate(Vector3.down * speed * Time.deltaTime);  
       
    }
}
