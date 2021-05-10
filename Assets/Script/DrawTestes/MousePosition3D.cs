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

    public Transform legPos;
    private int i;
    
    public void Spawn(Vector3 legPos)
    {
        
        var newLegPart = Instantiate(legPart,legPos,brush.transform.rotation);
        list.Add(newLegPart);
        if( i > 0)
        {
            list[i].transform.parent = list[0].transform;
        }
        
        i++;
       
    }

    public void DrawSet(Vector3 legPos)
    {
        list[0].transform.position = legPos;
        list.Clear();
        i = 0;
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
                Spawn(transform.position);
            }
            if(Input.GetMouseButtonUp(0))
            {
                DrawSet(legPos.transform.position);
            }    
        }
               
    }
    
}
