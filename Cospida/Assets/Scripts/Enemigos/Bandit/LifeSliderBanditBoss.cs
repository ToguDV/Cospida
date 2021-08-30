using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSliderBanditBoss : MonoBehaviour
{
    private GameObject objBanditBoss;
    private EnemigoConMovimiento enemigoConMovimiento;
    public Slider slider;
    void Start()
    {
        objBanditBoss = GameObject.Find("Boss bandido");
        enemigoConMovimiento = objBanditBoss.GetComponentInChildren<EnemigoConMovimiento>();
        slider.maxValue = enemigoConMovimiento.vida;

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemigoConMovimiento.vida;
    }
}
