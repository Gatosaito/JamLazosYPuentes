using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Terminar : MonoBehaviour
{
    public string Scena;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(Scena);

        }
    }

    public void cargarscena()
    {
        SceneManager.LoadScene(Scena);
    }    
}

