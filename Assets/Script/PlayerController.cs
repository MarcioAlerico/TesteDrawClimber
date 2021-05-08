using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    ////
    ////   class to controll player.
    ////

    //Load the legs and the force component
    public GameObject legZ;
    public GameObject legT;
    public GameObject legI;
    public GameObject legL;
    private ConstantForce myForce;

    //Control the active leg
    public bool activeLegZ;    
    public bool activeLegT = false;    
    public bool activeLegI = false;    
    public bool activeLegL = false;    
    

    // Start is called before the first frame update
    void Start()
    {   // ensures the varible starts with the right value.
        activeLegZ = true;
        // store the constant foce component from player.
        myForce = GetComponent<ConstantForce>();
    }

    // Update is called once per frame
    void Update()
    {
        if(activeLegZ == true)
        {
            myForce.enabled = false;

        }else
        {
            myForce.enabled = true;
            
        } 
        
        if(activeLegI == true)
        {
          legI.SetActive(true);
          legT.SetActive(false);
          legL.SetActive(false);
          legZ.SetActive(false);
        }
        if(activeLegL == true)
        {
          legI.SetActive(false);
          legT.SetActive(false);
          legL.SetActive(true);
          legZ.SetActive(false);
        }
        if(activeLegT == true)
        {
          legI.SetActive(false);
          legT.SetActive(true);
          legL.SetActive(false);
          legZ.SetActive(false);
        }
    }

    //call the leg shape I
    public void LegI()
    {
        activeLegI = true;
        activeLegL = false;
        activeLegT = false;
        activeLegZ = false;
    }

    //call the leg shape L
    public void LegL()
    {
        activeLegI = false;
        activeLegL = true;
        activeLegT = false;
        activeLegZ = false;
    }

    //call the leg shape T
    public void LegT()
    {
        activeLegI = false;
        activeLegL = false;
        activeLegT = true;
        activeLegZ = false;
    }
}
