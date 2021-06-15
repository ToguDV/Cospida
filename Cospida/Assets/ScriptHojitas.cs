using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptHojitas : MonoBehaviour
{
    float tiempoh;
    public GameObject prefab;
    public float ratio = 1f;
    public Vector2 rangeX;
    public Vector2 rangeY;
    
    void Update()
    {
        tiempoh += Time.deltaTime;
        if(tiempoh >= ratio)
        {
            tiempoh = 0;
            float x = Random.Range(rangeX.x, rangeX.y);
            float y = Random.Range(rangeY.x, rangeY.y);
            Vector3 position = new Vector3(x, y);
            Quaternion rotation = new Quaternion();
            Instantiate(prefab,position, rotation);
        }
    }
}
