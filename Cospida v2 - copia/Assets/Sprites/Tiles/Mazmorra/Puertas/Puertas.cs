using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puertas : MonoBehaviour
{
    public Animator animatorD;
    public Animator animatorI;
    int estadoPuerta;
    public int idPuerta;
    public bool isFirst;
    public Collider2D colisionador;
    // Start is called before the first frame update
    void Start()
    {
        estadoPuerta = PlayerPrefs.GetInt("Puerta" + idPuerta, 0);
        if (isFirst)
        {
            
            estadoPuerta = 1;
        }
        if(estadoPuerta==1){
            colisionador.enabled = false;
            animatorD.SetBool("Active",true);
            animatorI.SetBool("Active",true);
        }
    }

    public static void activarPuerta(int idPuerta)
    {
        PlayerPrefs.SetInt("Puerta" + idPuerta, 1);
    }
    public static void desactivarPuerta(int idPuerta)
    {
        PlayerPrefs.SetInt("Puerta" + idPuerta, 0);
    }
}
