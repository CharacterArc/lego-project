using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DropSlot : MonoBehaviour, IDropHandler
{
    DragnDrop ingrediant;
    [SerializeField] Image image;
    
    void Awake()
    {
        ingrediant = GetComponent<DragnDrop>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if(eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            image.color = ColorChange.colorChanger;
        }
    }

    public void ColorChanger()
    {
        image.color = Color.white;
    }
}
