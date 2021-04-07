using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GenerarMatriz : MonoBehaviour
{
    //VARIABLES
    public Image bloque1;
    public Image bloque2;
    public Image bloque3;
    public Image bloque4;
    public Image bloque5;
    public Image bloque6;
    public Image bloque7;
    public Image bloque8;
    public Image bloque9;
    public Image bloque10;
    public Image bloque11;
    public Image bloque12;
    public Image bloque13;
    public Image bloque14;
    public Image bloque15;
    public Image bloque16;
    public Sprite rojo;
    public Sprite amarillo;
    public Sprite verde;
    private static Image[,] matriz;
    private static int ronda;
    private int probabilidadRojo;
    private int probabilidadAmarillo;
    private int probabilidadVerde;

    void Start()
    {
        ronda = 1;
        matriz = new Image[,]{{bloque1, bloque2, bloque3, bloque4}, {bloque5, bloque6, bloque7, bloque8}, {bloque9, bloque10, bloque11, bloque12}, {bloque13, bloque14, bloque15, bloque16}};
        AsignarColor();
    }

    // Update is called once per frame
    private void AsignarColor()
    {
        System.Random random = new System.Random();
        VerificarRonda();
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                int num = random.Next(101);
                if(num <= probabilidadRojo)
                {
                    matriz[i, j].sprite = rojo;
                }
                else if(probabilidadRojo < num && num <= probabilidadAmarillo)
                {
                    matriz[i, j].sprite = amarillo;
                }
                else if(probabilidadAmarillo < num && num <= probabilidadVerde)
                {
                    matriz[i, j].sprite = verde;
                }
            }
        }
    }

    public void CambiarRonda()
    {
        ronda++;
        AsignarColor();
    }

    public void VerificarRonda()
    {
        if(ronda == 1)
        {
            probabilidadRojo = 45;
            probabilidadAmarillo = -1;
            probabilidadVerde = 100;
        }
        else if(ronda == 2)
        {
            probabilidadRojo = 20;
            probabilidadAmarillo = 40;
            probabilidadVerde = 100;
        }
        else if(ronda == 3)
        {
            probabilidadRojo = 30;
            probabilidadAmarillo = 60;
            probabilidadVerde = 100;
        }
        else
        {
            SceneManager.LoadScene("Mapa");
        }
    }
}
