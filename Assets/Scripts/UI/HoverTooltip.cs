using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverTooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float waitTime;
    public string toolTip;

    public MouseCursor mouseCursor;

    public void Awake()
    {
        mouseCursor = FindObjectOfType<MouseCursor>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        mouseCursor.StartCheck(this.gameObject, waitTime, toolTip);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseCursor.CallEnd(this.gameObject);
    }
}
