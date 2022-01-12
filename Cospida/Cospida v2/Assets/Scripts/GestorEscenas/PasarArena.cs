using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarArena : MonoBehaviour
{
    

    public static void ToNextArena(int nivel, int subnivel)
    {
        ToNextScene("Nivel"+nivel+"-"+(subnivel+1));
    }


    public static void ToExplorationMode(int nivel)
    {
        ToNextScene("Nivel" + nivel +"-"+"EX");
    }

    public static void ToBase()
    {
        ToNextScene("Mazmorra");
    }

    public static void ToBoss(int nivel, int subnivel)
    {
        ToNextScene("Boss"+nivel+"-"+subnivel);
    }



    public static void ToNextScene(string scena)
    {
        SceneManager.LoadScene(scena);
    }
}
