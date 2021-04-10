using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrizJugador : MonoBehaviour
{
    //VARIABLES
    public Button boton1;
    public Button boton2;
    public Button boton3;
    public Button boton4;
    public Button boton5;
    public Button boton6;
    public Button boton7;
    public Button boton8;
    public Button boton9;
    public Button boton10;
    public Button boton11;
    public Button boton12;
    public Button boton13;
    public Button boton14;
    public Button boton15;
    public Button boton16;
    public Sprite noColor;
    public static Button[,] matriz;

    //MÉTODOS
    void Start()
    {
        matriz = new Button[,]{{boton1, boton2, boton3, boton4}, {boton5, boton6, boton7, boton8}, {boton9, boton10, boton11, boton12}, {boton13, boton14, boton15, boton16}};
    }

    public void ResetearColor()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                matriz[i, j].image.sprite = noColor;
                matriz[i, j].GetComponent<CambiarBoton>().color = 0;
                matriz[i, j].GetComponent<CambiarBoton>().estaColoreado = false;
            }
        }
    }
}
