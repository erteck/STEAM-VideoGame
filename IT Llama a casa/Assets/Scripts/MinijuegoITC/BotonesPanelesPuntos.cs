using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Da funcionalidad a los botónes de los paneles nivel completado y minijuego completado,
 * oculta el respectivo panel al presionar el botón
 */
public class BotonesPanelesPuntos : MonoBehaviour
{
    // Referencia al panel de Nivel completado
    public GameObject panelNivelCompletado;
    // Referencia al panel de Minijuego completado
    public GameObject panelMinijuegoCompletado;

    public void SiguienteNivel()
    {
        panelNivelCompletado.SetActive(false);
    }

    public void EscenaFinal()
    {
        FinalizarJuego.instance.RevisarPiezas();
        // Agregar que el jugador reaparezca en la misma posición
    }
}
