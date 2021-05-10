using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushController : MonoBehaviour
{
    public Transform cameraPos;

    // Update is called once per frame
    void Start()
    {
       transform.LookAt(cameraPos);
    }
}
