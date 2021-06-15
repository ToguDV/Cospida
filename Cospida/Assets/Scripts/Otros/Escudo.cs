using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escudo : MonoBehaviour
{
    EnemigoBasico enemigo;
    public float duration = 3f;
    // Start is called before the first frame update
    void Start()
    {
        enemigo = GetComponentInParent<EnemigoBasico>();
        enemigo.setProtected(true);
        Invoke("DesactivarEscudo", duration);
    }

    // Update is called once per frame
    void DesactivarEscudo()
    {
        enemigo.setProtected(false);
        Destroy(gameObject);
    }
}
