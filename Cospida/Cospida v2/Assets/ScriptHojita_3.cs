using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHojita_3 : MonoBehaviour
{
    float tiempoh;
    public GameObject Prefab;

    void Update()
    {
        tiempoh += Time.deltaTime;
        if (tiempoh >= 2f)
        {
            tiempoh = 0;
            float x = Random.Range(-30f, 30f);
            float y = Random.Range(-30f, 30f);
            Vector3 position = new Vector3(x, y, 0);
            Quaternion rotation = new Quaternion();
            Instantiate(Prefab, position, rotation);
        }
    }
}
