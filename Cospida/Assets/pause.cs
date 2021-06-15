using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pause : MonoBehaviour
{
    public static bool active;
    Canvas canvasf;
    public Slider sliderVol;
    public GameObject btnPausa;
    GameObject canvasPrincial;
    GameObject canvasPausa;
    // Start is called before the first frame update
    void Start()
    {
        canvasPrincial = GameObject.Find("Canvas UI");
        canvasPausa = GameObject.Find("Pausa");
        active = false;
        btnPausa.transform.SetParent((active) ? canvasPausa.transform : canvasPrincial.transform);
        Time.timeScale = 1f;

        canvasf = GetComponent<Canvas>();
        canvasf.enabled = false;
        sliderVol.interactable = false;
        AudioListener.pause = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            Pausar();
        }
    }

    public void Pausar()
    {
        active = !active;
        btnPausa.transform.SetParent((active) ? canvasPausa.transform : canvasPrincial.transform);
        canvasf.enabled = active;
        sliderVol.interactable = !sliderVol.interactable;
        AudioListener.pause = !AudioListener.pause;

        Time.timeScale = (active) ? 0 : 1f;
    }


}
