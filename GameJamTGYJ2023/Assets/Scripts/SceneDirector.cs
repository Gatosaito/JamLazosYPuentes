using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    [Header("CinemaInicio")]
    public PlayableDirector directorInicio;
    [SerializeField] int waitForIniciar;
    [Space(2)]
    [Header("HOla")]
    public PlayableDirector directorPaneo;
    public PlayableDirector directorBotones;
    public PlayableDirector cargarpantalla;
    public AudioSource musiquitaFachera;

    private void Awake()
    {
        //musiquitaFachera = FindObjectOfType<AudioSource>();
    }
    void Start()
    {
        StartCoroutine(EsperarInicio());
    }

    void Update()
    {
        InicioJuego();
    }

    public void InicioJuego()
    {
        if (directorInicio.time >= 2f)
        {
            directorInicio.gameObject.SetActive(false);
        }
    }   

    public void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo");
    }
    public void Jugar()
    {
       StartCoroutine(WaitForJugar());
    }
    
    IEnumerator EsperarInicio()
    {
        yield return new WaitForSeconds(waitForIniciar);
        Debug.Log("Empezó");
        directorInicio.Play();
        yield return new WaitForSeconds(1f);    
        musiquitaFachera.Play();
    } 
    IEnumerator WaitForJugar()
    {
        directorBotones.Play();
        yield return new WaitForSeconds(2f);
        cargarpantalla.Play();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
        Debug.Log("Empezando");
    }
}
