using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    
   //Se definen las dos variables tipo AudioSource para daño recibido y el ataque espada
    public AudioSource hurt;
    public AudioSource sword;

    //Se definen las variables que generarán los numeros aleatorios
    int valorSword;
    int valorHurt;

    void Start()
    {
        
    }

    void Update()
    {
        //Las variables toman un numero aleatorio entre el rango definido
        valorSword = Random.Range(1, 4);
        valorHurt = Random.Range(1, 4);
        
    }

    public void attack()
    {
        //Se define la ruta en donde están alojados los clips, además, se usa el numero aleatorio para cambiar de clips
        sword.clip = Resources.Load<AudioClip>("SoundPlayer/Sword/Hit  Air " + valorHurt);
        sword.Play();
    }

    public void hurtPlayer()
    {
        //Se define la ruta en donde están alojados los clips, además, se usa el numero aleatorio para cambiar de clips
        hurt.clip = Resources.Load<AudioClip>("SoundPlayer/Hurt/Hurt " + valorHurt);
        hurt.Play();
    }


}
