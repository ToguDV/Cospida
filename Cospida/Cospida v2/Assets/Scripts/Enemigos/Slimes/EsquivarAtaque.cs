using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EsquivarAtaque : MonoBehaviour
{
    SlimeController slimeController;
    public int contador = 0;
    public int maxGolpes = 5;
    int random = 0;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(1, 11);
        

        slimeController = GetComponentInParent<SlimeController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ataque"))
        {
            random = Random.Range(1, 11);
            if (contador <= maxGolpes && random != 1) {
                contador++;
                
            }

            else
            {
                slimeController.setProtected(false);
            }

        }
    }
}
