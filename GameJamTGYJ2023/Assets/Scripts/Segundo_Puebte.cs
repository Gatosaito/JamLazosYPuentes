using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Segundo_Puebte : MonoBehaviour
{
    public GameObject balon;
    public Animator animator;
    private void Update()
    {
        if(balon != null)
        {
            animator.SetBool("Action", true);
        }
    }
}
