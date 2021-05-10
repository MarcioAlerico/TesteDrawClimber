using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition3D : MonoBehaviour
{
    public Camera mainCamera;

    public LayerMask layerMask;

    public GameObject legPart;
    public GameObject brush;
    public List <GameObject> list;

    public GameObject legRPos;
    public GameObject legLPos;
    private int i;    
    public void LegCreation(Vector3 legPos)
    {
        
        var newLegPart = Instantiate(legPart,legPos,brush.transform.rotation);
        list.Add(newLegPart);
        if( i > 0)
        {
            list[i].transform.parent = list[0].transform;
        }
        i++;
       
    }

    public void DrawSet(GameObject legRPos,GameObject legLPos)
    {
        
        list[0].transform.position = legRPos.transform.position;
        list[0].tag = "Leg";
        list[0].transform.parent = legRPos.transform;

        var newLeg = Instantiate(list[0],legLPos.transform.position,Quaternion.identity);

        newLeg.transform.Rotate(0,180,0);
        newLeg.tag = "Leg";
        newLeg.transform.parent = legLPos.transform;
        newLeg.transform.localScale = list[0].transform.localScale;

        i=0;
        list.Clear();        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit raycastHit,float.MaxValue, layerMask))
        {
            transform.position = raycastHit.point;
            if(Input.GetMouseButton(0))
            {
                //mainCamera.transform.parent = brush.transform;
                LegCreation(transform.position);
            }
            if(Input.GetMouseButtonUp(0))
            {
                DrawSet(legRPos,legLPos);
            }    
        }
               
    }
    
}
