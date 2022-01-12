using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FaseController : MonoBehaviour
{
    public Image[] puntosFases;
    public static int bossFase;
    public Sprite puntoLleno;
    public Sprite puntoVacio;
    void Start()
    {
        
        bossFase = 0;
        for (int i = 0; i <= Spawner.faseIndex- 2; i++)
        {
            puntosFases[i].sprite = puntoLleno; 
        }
    }

    // Update is called once per frame
    public void Actualizar()
    {
        puntosFases[Spawner.faseIndex - 2].sprite = puntoLleno;
    }
}
