using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSliderBanditBoss : MonoBehaviour
{
    public GameObject objBanditBoss;
    private EnemigoConMovimiento enemigoConMovimiento;
    public Slider slider;
    void Start()
    {
        enemigoConMovimiento = objBanditBoss.GetComponentInChildren<EnemigoConMovimiento>();
        slider.maxValue = enemigoConMovimiento.vida;

    }

    // Update is called once per frame
    void Update()
    {
        slider.value = enemigoConMovimiento.vida;
    }
}
