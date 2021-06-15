using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TaskController : MonoBehaviour
{
    public TextMeshProUGUI[] textos;
    public string[] descripciones;
    public bool[] haveCount; //Verifica si tiene contador o se completa con una simple acción
    public int[] progressValue; //Almacena progreso actual de la tarea
    public int[] objetiveValue; //La cantidad de progreso que se necesita para completar la tarea
    public string[] idCountType; //Especifica tipo de contador, ya sea para kills de slimes, llaves, etc.
    public Image[] checks; //Icono que indica si una tarea está completada o nel;
    public Sprite taskCompleted;
    public Sprite taskPending;
    public GameObject GFX;


    //Constantes de ids para contadores de kills de enemigos
    public const string IdSlimeBlue = "SlimeBlue";
    public const string IdAnySlime = "AnySlime";
    public const string IdArcher0 = "Archer0";
    public const string IdMago0 = "Mago0";
    public const string IdKnife0 = "Knife0";
    public const string Id = "Knife0";


    void Start()
    {

        int indexDesc = 0;
        foreach (TextMeshProUGUI texto in textos) /*Se actualizan las descripciones de las tareas
                                                    que se pueden ver*/
        {
            checks[indexDesc].sprite = taskPending;
            texto.text = descripciones[indexDesc] + " " + progressValue[indexDesc] + "/" + objetiveValue[indexDesc];
            indexDesc++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //EJEMPLO PARA TESTEAR
        /*  if (Input.GetKeyDown(KeyCode.F))
          {
              updateAnyCountForID(IdSlimeBlue);
          }

          */
    }

    public void taskComplete(int index)
    {
        textos[index].fontStyle = (FontStyles)64;
        checks[index].sprite = taskCompleted;
    }

    public void taskComplete(string idCount)
    {
        int index;
        index = 0;

        foreach (TextMeshProUGUI texto in textos) /*Se actualizan las descripciones de las tareas */
        {
            if (idCountType[index] == idCount)
            {
                taskComplete(index);
                break;
            }


            index++;

        }

    }

    public void ShowHide()
    {
        GFX.SetActive(!GFX.activeSelf);
    }

    public void updateAnyCountForID(string idCount)
    {
        int index;
        index = 0;
        foreach (TextMeshProUGUI texto in textos) /*Se actualizan las descripciones de las tareas */
        {
            if (haveCount[index] && idCountType[index] == idCount)
            {
                progressValue[index]++;
                texto.text = descripciones[index] + " " + progressValue[index] + "/" + objetiveValue[index];
                if (progressValue[index] >= objetiveValue[index])
                {
                    taskComplete(index);
                }
                break;
            }


            index++;

        }
    }




}
