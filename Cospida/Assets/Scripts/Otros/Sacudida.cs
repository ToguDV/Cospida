using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sacudida : MonoBehaviour
{
    Transform camaraSacudir;


    private void Start()
    {
        camaraSacudir = GameObject.Find("CM").transform;
    }

    IEnumerator sacudida(float magnitudSacudida, float duracion)
    {
        while (magnitudSacudida > duracion)
        {
            camaraSacudir.rotation = Quaternion.Euler(
                Random.Range(-magnitudSacudida, magnitudSacudida),
                Random.Range(-magnitudSacudida, magnitudSacudida),
                Random.Range(-magnitudSacudida, magnitudSacudida)
                );
            magnitudSacudida *= .9f;
            yield return new WaitForFixedUpdate();
        }
        yield return null;
    }


    public void sacudirCamera(float magnitud, float duracion)
    {
        
        
        StartCoroutine(sacudida(magnitud, duracion));
    }
}
