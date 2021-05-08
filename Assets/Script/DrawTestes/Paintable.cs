using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintable : MonoBehaviour
{
    public GameObject Brush;
    
    public float BrushSize = 0.1f;

    // public float sensitivity=0.5f;
    // public float smoothing = 2f;

    // Vector2 mouseLook;
    // Vector2 smoothV;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        // md =Vector2.Scale(md, new Vector2(sensitivity*smoothing , sensitivity * smoothing));
        // smoothV.x = Mathf.Lerp(smoothV.x,md.x,1f/smoothing);
        // smoothV.y = Mathf.Lerp(smoothV.y,md.y,1f/smoothing);

        if(Input.GetMouseButton(0))
        {
            // var go = Instantiate(Brush, md, Quaternion.identity, transform);
            // go.transform.localScale = Vector3.one * BrushSize;

            var Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(Ray, out hit))
            {
                 var go = Instantiate(Brush, hit.point, Quaternion.identity, transform);
                go.transform.localScale = Vector3.one * BrushSize;

            }
        }
    }
}
