using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CambiarBoton : MonoBehaviour
{
    //VARIABLES
    public Sprite noColor;
    public Sprite rojo;
    public Sprite amarillo;
    public Sprite verde; 

    public int color = 0;
    public bool estaColoreado = false;

    //MÉTODOS
    public void CambiarColor(Button button)
    {
        color++;
        if(color == 1)
        {
            button.image.sprite = rojo;
            estaColoreado = true;
        }
        else if(color == 2)
        {
            button.image.sprite = amarillo;
        }
        else if(color == 3)
        {
            button.image.sprite = verde;
        }
        else
        {
            button.image.sprite = noColor;
            color = 0;
            estaColoreado = false;
        }
    }
}
