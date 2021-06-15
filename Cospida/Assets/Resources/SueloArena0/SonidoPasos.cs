using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoPasos : MonoBehaviour
{
    //Se definen las variable publica tipo AudioSource para el pasto y la tierra
    public AudioSource audio;

    //Se definen las variables que tomarán el numero para avanzar en la tierra o cesped
    int valorGrass=0;
    int valorTierra=0;
    
    //Variable tipo booleana que define si está en la tierra o no
    bool enTierra=false;
    void Start()
    {

    }

    void Update()
    {

    }

    public void reproducirSonido()
    {
        if (enTierra==true)
        {
            valorTierra++;
            if (valorTierra > 4)
            {
                valorTierra = 1;
            }
            //Se define la ruta en donde están alojados los clips, además, se usa el numero aleatorio para cambiar de clips
            audio.clip = Resources.Load<AudioClip>("SueloArena0/Pasos/Pasos Tierra " + valorTierra);
            audio.Play();
        }
        else
        {
            valorGrass++;
            if (valorGrass>5)
            {
                valorGrass = 1;
            }
            
            //Se define la ruta en donde están alojados los clips, además, se usa el numero aleatorio para cambiar de clips
            audio.clip = Resources.Load<AudioClip>("SueloArena0/Pasos/Footstep Grass " + valorGrass);
            audio.Play();
        }
       
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Si hay colisión entre con la etiqueta Player se define que está en la tierra
        if (collision.gameObject.CompareTag("Player"))
        {
            enTierra = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    { 
        //Si sale de el Collider el personaje con la etiqueta Player se define que está fuera de la tierra
        if (collision.gameObject.CompareTag("Player"))
        {
            enTierra = false;
        }
    }

}
