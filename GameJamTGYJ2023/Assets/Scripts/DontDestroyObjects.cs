using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObjects : MonoBehaviour
{
    private void Awake()
    {
        MusiquitaFacherita();
    }

    void MusiquitaFacherita() 
    {
        if (FindObjectsOfType(GetType()).Length >1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
