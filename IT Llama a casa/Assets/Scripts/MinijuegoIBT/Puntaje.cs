using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public Text puntos;
    public Text puntosFinal;
    private float puntosTotal;
    private Tiempo tiempo;

    void Start()
    {
        tiempo = FindObjectOfType<Tiempo>();
    }

    public void AsignarPuntosPrecision(int casillas)
    {
        if(tiempo.estaReintentando)
        {
            //Número limitado de reintentos
            puntosTotal += casillas * 5;
        }
        else
        {
            puntosTotal += casillas * 10;
        }
    }

    public void AsignarPuntosTiempo(float tiempoPuntos)
    {
        tiempoPuntos = Mathf.Floor(tiempoPuntos);
        if(tiempo.estaReintentando)
        {
            puntosTotal += tiempoPuntos * 5;
        }
        else
        {
            puntosTotal += tiempoPuntos * 10;
        }
    }

    public void AsignarPuntosDiagnostico(int puntaje)
    {
        puntosTotal += puntaje;
    }

    public void GrabarPuntos()
    {
        print(puntosTotal);
        puntos.text = puntosTotal.ToString();
        puntosFinal.text = puntosTotal.ToString();
    }
}
