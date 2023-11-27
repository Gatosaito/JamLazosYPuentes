using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    private new Transform camera;
    public float rayDistance;
    public int objetos_Cambiados;
    public GameObject balon;
    public GameObject felcha;

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
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!IsColorRed(hit.transform.gameObject))
                {
                    ChangeColorToRed(hit.transform.gameObject);
                    objetos_Cambiados++;

                    if(objetos_Cambiados == 3)
                    {
                        balon.SetActive(true);
                        felcha.SetActive(true);
                    }
                }
            }
        }
    }

    private void ChangeColorToRed(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.green;
        }
    }

    private bool IsColorRed(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            return renderer.material.color == Color.green;
        }
        return false;
    }
}
