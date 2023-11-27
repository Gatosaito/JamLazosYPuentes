using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puente_2 : MonoBehaviour
{
    public GameObject balon;
    public Animator puenteAnimator;
    public Animator balon_Anim;
    public GameObject Flecha;
    public bool balonActivado = false;

    private void Start()
    {
        balonActivado = false;
    }

    private void Activar()
    {
        puenteAnimator.SetBool("Action", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            balon_Anim.SetBool("Action", true);
            Invoke("Activar", 2f);
            Flecha.SetActive(false);
            balonActivado = true;
        }
    }

}