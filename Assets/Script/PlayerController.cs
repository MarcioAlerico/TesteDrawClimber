using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    private ConstantForce myForce;
    public GameObject legs;
    public int contaLegs = 0;
    // Start is called before the first frame update
    void Start()
    {    
        // store the constant foce component from player.
        myForce = GetComponent<ConstantForce>();

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //Stops the character in the finish line
    public void OnTriggerEnter(Collider other)
    {
        //check if the player entered is the finish line area
       if(other.tag == "Finish")
       {
         myForce.enabled = false;
        
       }
        
    }
   
}
