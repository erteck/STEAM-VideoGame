using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Da funcionalidad a los botónes de las instrucciones del minijuego
 * Autor: Erick Bustos
 */
public class BotonesInstrucciones : MonoBehaviour
{
    public GameObject panelactual;
    public GameObject panelsiguiente;
    public GameObject panelanterior;

    public void CambiaPanel()
    {
        panelactual.SetActive(false);
        panelsiguiente.SetActive(true);
    }

    public void RegresaPanel()
    {
        panelactual.SetActive(false);
        panelanterior.SetActive(true);
    }

    public void IniciaJuego()
    {
        panelactual.SetActive(false);
    }
}
