using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    public float tiempoRestante;
    private bool estaCorriendo = true;
    private bool estaCopiando;
    public Text textoTiempo;
    public Text textoMemoCop;
    public GameObject matrizCopiar;
    public GameObject matrizJugador;
    public static Tiempo instance;
    private VerificarMatrices verificarMatrices;

    void Start()
    {
        matrizJugador.SetActive(false);
        float segundos = Mathf.FloorToInt(tiempoRestante % 60);
        textoTiempo.text = segundos.ToString();
        verificarMatrices = FindObjectOfType<VerificarMatrices>();
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
            else if(segundos < 0 && estaCopiando)
            {
                estaCopiando = false;
                estaCorriendo = false;
                verificarMatrices.RevisarMatrices();
            }
            else
            {
                matrizJugador.SetActive(true);
                matrizCopiar.SetActive(false);
                AsignarTiempo();
                textoMemoCop.text = "Copia";
                estaCopiando = true;
            }
        }
    }

    public void ResetearContador(bool reintentar)
    {
        AsignarTiempo();
        estaCorriendo = true;
        if(reintentar)
        {
            estaCopiando = true;
        }
    }

    public void AsignarTiempo()
    {
        if(GenerarMatriz.ronda == 1)
        {
            tiempoRestante = 45;
        }
        else if(GenerarMatriz.ronda == 2)
        {
            tiempoRestante = 25;
        }
        else if(GenerarMatriz.ronda == 3)
        {
            tiempoRestante = 15;
        }
    }

    public void ResetearEstaCopiando()
    {
        estaCopiando = false;
    }

    public void ResetearEstaCorriendo()
    {
        estaCorriendo = false;
    }
}
