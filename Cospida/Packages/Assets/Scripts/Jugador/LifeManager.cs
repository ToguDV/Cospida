using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static bool actualizar = false;
    public static int index = 0;
    public GameObject[] corazones;
    public static int ultimo = 0;
    public int i = 0;
    public int j = 0;
    public static bool curar;

    // Start is called before the first frame update
    void Start()
    {

        ActivarCorazones();
       
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.G))
        {
            CurarCorazones(0.5f);
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            CurarCorazones(1f);
        }
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
