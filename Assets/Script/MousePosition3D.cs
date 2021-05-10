using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// Control the draw mechanics and the position of legs
/// </summary>
public class MousePosition3D : MonoBehaviour
{
    // refence to second camera
    public Camera mainCamera;
    // layer were is the canvas to draw
    public LayerMask layerMask;
    //prefab used to create the leg
    public GameObject legPart;
    //follows mouse position
    public GameObject brush;
    // all parts of the leg
    public List <GameObject> list;
    //leg spawn right
    public GameObject legRPos;
    //leg spawn left
    public GameObject legLPos;
    //control the father object in leg
    private int i;
    
    //Start Drawing the leg.
    public void LegCreation(Vector3 legPos)
    {
        //create on mouse position a leg part
        var newLegPart = Instantiate(legPart,legPos,brush.transform.rotation);
        // add this part on a list
        list.Add(newLegPart);
        //check if is the first part
        if( i > 0)
        {
            // set the first part on the list as father
            list[i].transform.parent = list[0].transform;
        }
        //increase the controll parts
        i++;
       
    }
    // Set the correct position and nunber of legs
    public void DrawSet(GameObject legRPos,GameObject legLPos)
    {
        //takes the father and set to correct position of player
        list[0].transform.position = legRPos.transform.position;

        // add the tag this will be used for future leg removal
        list[0].tag = "Leg";

        //set the leg as child of player
        list[0].transform.parent = legRPos.transform;

        // create a new leg the player need 2
        var newLeg = Instantiate(list[0],legLPos.transform.position,Quaternion.identity);

        // set the correct rotation to the new leg
        newLeg.transform.Rotate(0,180,0);

        // add a tag to the new leg
        newLeg.tag = "Leg";
        // set the new leg as parent of player
        newLeg.transform.parent = legLPos.transform;

        // fix the scale
        newLeg.transform.localScale = list[0].transform.localScale;

        //reset the count
        i=0;
        // clear the list to create another leg in the future
        list.Clear();        
    }

    // Update is called once per frame
    void Update()
    {
        // used to move the brush on scream and just on canvas
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        // check if the mouse is on right location and takes the position
        if(Physics.Raycast(ray, out RaycastHit raycastHit,float.MaxValue, layerMask))
        {
            //save the mouse position on canvas
            transform.position = raycastHit.point;
            // check if the left mouse button are pressed
            if(Input.GetMouseButton(0))
            {
                // create the legpart 
                LegCreation(transform.position);
            }
            //check if the left mouse button is released
            if(Input.GetMouseButtonUp(0))
            {
                // position the lag in right spot
                DrawSet(legRPos,legLPos);
            }    
        }
               
    }
    
}
