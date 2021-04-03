using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/*
 * Permite que una línea de código vacía capte uno de los bloques de código ya predefinidos
 */
public class LineaCodigo : MonoBehaviour, IDropHandler
{
      public void OnDrop(PointerEventData eventData)
      {
          if (eventData.pointerDrag != null)
          {
              eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition =
                  GetComponent<RectTransform>().anchoredPosition;
          }
      }
}
