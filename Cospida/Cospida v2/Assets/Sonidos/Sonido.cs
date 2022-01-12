using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{

    //Se declaran las dos pistas de sonido
    public AudioClip clipLoop;
    public AudioClip clipInicio;
    public AudioSource audioSource;
    public GameObject Controlador;


    private void Start()
    {
        audioSource.clip = clipInicio;
        audioSource.Play();
    }
    void Update()
    {
        //Si la pista 1 no se está reproduciendo entonces se desactiva y se activa la pista 2
        if (!audioSource.isPlaying && !pause.active)
        {
            audioSource.clip = clipLoop;
            audioSource.Play();
            audioSource.loop = true;
            this.enabled = false;
        }


    }

    public void Desactivarsonido()
    {
        audioSource.Stop();
    }
}
