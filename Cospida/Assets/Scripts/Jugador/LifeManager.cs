using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static bool actualizar = false;
    public static int index = 0;
    public GameObject[] corazones;
    public static int ultimo = 0;
    int i = 0;
    int j = 0;
    public static bool curar;

    // Start is called before the first frame update
    void Start()
    {
        actualizar = false;
        index = 0;
        ultimo = 0;
        i = 0;
        j = 0;
        curar = false;
        ActivarCorazones();
       
    }

    // Update is called once per frame
    void Update()
    {
        

      
    }

    void ActivarCorazones()
    {
        for (int index = 0; index < Player.vidaMax; index++)
        {
            ultimo++;
            corazones[index].SetActive(true);

        }


    }

    public void DamageCorazones(float damage)
    {
        corazones[ultimo - 1].GetComponent<Corazon>().Damage(damage);

    }

    public void CurarCorazones(float curacion)
    {
        corazones[ultimo - 1].GetComponent<Corazon>().Curar(curacion);
    }
}
