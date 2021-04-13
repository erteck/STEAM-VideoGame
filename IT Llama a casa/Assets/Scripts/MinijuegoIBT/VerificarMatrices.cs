using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VerificarMatrices : MonoBehaviour
{
    public GameObject pantallaResultado;
    public Text textoRes;
    private int counter;
    
    public void RevisarMatrices()
    {
        for(int i = 0; i < 4; i++)
        {
            for(int j = 0; j< 4; j++)
            {
                if(GenerarMatriz.matriz[i, j].sprite == MatrizJugador.matriz[i, j].image.sprite)
                {
                    counter++;
                }
            }
        }
        PantallaResultado();
    }

    public void PantallaResultado()
    {
        pantallaResultado.SetActive(true);
        Time.timeScale = 0;
        if(counter == 1)
        {
            textoRes.text = "Tienes " + counter.ToString() + " casilla correcta de 16\n ¿Deseas reintentarlo?";

        }
        else
        {
            textoRes.text = "Tienes " + counter.ToString() + " casillas correctas de 16\n ¿Deseas reintentarlo?";
        }
        counter = 0;
    }

    public void DesactivarResultado()
    {
        Time.timeScale = 1;
        pantallaResultado.SetActive(false);
    }
}
