using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puente_Anim : MonoBehaviour
{
    public Animator puenteAnimator;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            puenteAnimator.SetBool("Action", true);
        }
    }
}
