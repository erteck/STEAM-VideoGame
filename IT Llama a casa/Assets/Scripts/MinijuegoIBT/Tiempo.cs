using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    public float tiempoRestante;
    private bool estaCorriendo = true;
    public Text textoTiempo;
    public Text textoMemoCop;
    public GameObject matrizCopiar;
    public GameObject matrizJugador;
    public static Tiempo instance;

    void Start()
    {
        matrizJugador.SetActive(false);
        float segundos = Mathf.FloorToInt(tiempoRestante % 60);
        textoTiempo.text = segundos.ToString();
        AsignarTiempo();
    }

    void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if(estaCorriendo)
        {
            float segundos = Mathf.FloorToInt(tiempoRestante % 60);

            if(segundos >= 0)
            {
                textoTiempo.text = segundos.ToString();
                tiempoRestante -= Time.deltaTime;
            }
            else
            {
                matrizJugador.SetActive(true);
                matrizCopiar.SetActive(false);
                estaCorriendo = false;
                textoMemoCop.text = "Copia";
            }
        }
    }

    public void ResetearContador()
    {
        AsignarTiempo();
        estaCorriendo = true;
    }

    public void AsignarTiempo()
    {
        if(GenerarMatriz.ronda == 1)
        {
            tiempoRestante = 60;
        }
        else if(GenerarMatriz.ronda == 2)
        {
            tiempoRestante = 45;
        }
        else if(GenerarMatriz.ronda == 3)
        {
            tiempoRestante = 25;
        }
    }
}
