using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * Permite arrastrar objetos en pantalla con el uso del mouse
 * Autor: Erick Bustos
 */

public class Arrastrar : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup; 
    public GameObject originalObject;
    public GameObject parent;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Al comienzo del arrastre
    public void OnBeginDrag(PointerEventData eventData)
    {
        
        canvasGroup.alpha = .5f; //Permite hacer opaco el objeto cuando está en movimiento
        canvasGroup.blocksRaycasts = false; //Se desactiva la capacidad del objeto de capturar eventos al estar en movimiento
    }
        
    // Durante el arrastre
    public void OnDrag(PointerEventData eventData)
    {
        //Mueve el objeto seleccionado hacía la posición del mouse, corrige el tomando en cuenta la escala del canvas
        rectTransform.anchoredPosition += eventData.delta
                                          / canvas.scaleFactor;
    }
    // Al finalizar el arrastre
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
    // Cuando se selecciona el objeto con el mouse
    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject BlockClone = Instantiate(originalObject,parent.transform);
    }

}
