using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    private new Transform camera;
    public float rayDistance;

     void Start()
    {
        camera = transform.Find("Camera");
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.red);

    }
}
