using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Idioma : MonoBehaviour
{
    private string idioma;
    public Button buttonEs;
    public Button buttonEn;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpanishIsSelected()
    {
        if (idioma == "ingles")
        {
            buttonEn.enabled = false;
            buttonEn.enabled = true;
        }
        idioma = "español";
        print(idioma);
    }
    public void EnglishIsSelected()
    {
        if (idioma == "español")
        {
            buttonEs.enabled = false;
            buttonEs.enabled = true;
        }
        idioma = "ingles";
        print(idioma);

    }

}
