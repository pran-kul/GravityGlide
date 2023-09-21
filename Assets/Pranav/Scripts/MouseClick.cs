using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseClick : MonoBehaviour, IPointerDownHandler
{
    public UIManager uimanager;
    public string myType;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        uimanager.BoxSpawnOnClick(myType);
    }
}


