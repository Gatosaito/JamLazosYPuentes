using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float runSpeed = 7;
    public float rotationSpeed = 250;

    public Animator animator;

    private float x, y;

    private void Update()
    {
        x = Input.GetAxis("Horizontal");
        //if(Input.GetAxis
        
        y = Input.GetAxis ("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);

        transform.Translate(0,0,y * Time.deltaTime * runSpeed);
    }
}
