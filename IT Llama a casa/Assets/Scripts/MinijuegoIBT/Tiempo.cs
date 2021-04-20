using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    public float tiempoRestante;
    private int tiempoTotal = 30;
    private bool estaCorriendo = true;
    private bool estaCopiando;
    public bool estaReintentando;
    public Text textoMemoCop;
    public GameObject matrizCopiar;
    public GameObject matrizJugador;
    public Image barraTiempo;
    public static Tiempo instance;
    private VerificarMatrices verificarMatrices;

    void Start()
    {
        AsignarTiempo();
        matrizJugador.SetActive(false);
        
        float segundos = Mathf.FloorToInt(tiempoRestante % 60);
        verificarMatrices = FindObjectOfType<VerificarMatrices>();
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
                tiempoRestante -= Time.deltaTime;
                barraTiempo.rectTransform.localPosition = new Vector3(tiempoRestante * barraTiempo.rectTransform.rect.width / tiempoTotal - barraTiempo.rectTransform.rect.width, 0, 0);
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
        estaReintentando = false;
        if(reintentar)
        {
            estaReintentando = true;
        }
    }

    public void AsignarTiempo()
    {
        if(GenerarMatriz.ronda == 1)
        {
            tiempoRestante = 30;
            tiempoTotal = 30;
        }
        else if(GenerarMatriz.ronda == 2)
        {
            tiempoRestante = 25;
            tiempoTotal = 25;
        }
        else if(GenerarMatriz.ronda == 3)
        {
            tiempoRestante = 15;
            tiempoTotal = 15;
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
