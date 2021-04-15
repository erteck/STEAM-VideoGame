using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Diagnostico : MonoBehaviour
{
    public GameObject matrizJugador;
    public GameObject matrizCopiar;
    public GameObject panelTiempo;
    public GameObject botonVerificar;
    public GameObject panelDiagnostico;
    public GameObject panelRecuerda;
    public GameObject botDiag1;
    public GameObject botDiag2;
    public GameObject botCont;
    public Text textoDiagnostico;
    private Puntaje puntaje;
    private bool diagnostico;
    private bool diagnosticoJugador;

    void Start()
    {
        puntaje = FindObjectOfType<Puntaje>();
    }

    public void MostrarDiagnostico()
    {
        matrizJugador.SetActive(false);
        matrizCopiar.SetActive(true);
        panelTiempo.SetActive(false);
        botonVerificar.SetActive(false);
        panelDiagnostico.SetActive(true);
        botDiag1.SetActive(true);
        botDiag2.SetActive(true);
        botCont.SetActive(false);
        panelRecuerda.SetActive(true);
    }

    public void OcultarDiagnostico()
    {
        panelTiempo.SetActive(true);
        botonVerificar.SetActive(true);
        panelDiagnostico.SetActive(false);
        panelRecuerda.SetActive(false);
        textoDiagnostico.text = "¿Cuál es el diagnóstico?";
    }

    public void AsignarDiagnostico()
    {
        if(GenerarMatriz.diagRojo > GenerarMatriz.diagVerde)
        {
            diagnostico = false;
        }
        else if(GenerarMatriz.diagRojo < GenerarMatriz.diagVerde)
        {
            diagnostico = true;
        }
    }

    public void AsignarDiagnosticoPJ(bool diag)
    {
        diagnosticoJugador = diag;
        VerificarDiagnostico();
    }

    private void VerificarDiagnostico()
    {
        if(diagnosticoJugador == diagnostico)
        {
            textoDiagnostico.text = "¡Tu diagnóstico es correcto!";
            puntaje.AsignarPuntosDiagnostico(100);
        }
        else
        {
            textoDiagnostico.text = "Tu diagnóstico es incorrecto :(";
            puntaje.AsignarPuntosDiagnostico(25);
        }
        botDiag1.SetActive(false);
        botDiag2.SetActive(false);
        botCont.SetActive(true);
    }
}
