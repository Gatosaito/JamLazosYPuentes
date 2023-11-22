using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    private new Transform camera;
    public float rayDistance;
    public int objetos_Cambiados;

    void Start()
    {
        camera = transform.Find("Camera");
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, rayDistance, LayerMask.GetMask("Boton")))
        {
            Debug.Log(hit.transform.name);

            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeColorToRed(hit.transform.gameObject);
            }
        }
    }

    private void ChangeColorToRed(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.red;
        }
    }
}
