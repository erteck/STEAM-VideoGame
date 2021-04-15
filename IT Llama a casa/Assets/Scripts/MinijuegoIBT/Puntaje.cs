using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje : MonoBehaviour
{
    public Text puntos;
    private float puntosTotal;

    public void AsignarPuntosPresicion(int casillas)
    {
        puntosTotal += (casillas * 160)/16;
    }

    public void AsignarPuntosTiempo(float tiempo)
    {
        tiempo = Mathf.Floor(tiempo);
        puntosTotal += tiempo * 10;
    }

    public void AsignarPuntosDiagnostico(int puntaje)
    {
        puntosTotal += puntaje;
    }

    public void GrabarPuntos()
    {
        puntos.text = puntosTotal.ToString();
    }
}
