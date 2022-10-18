using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class DropSlot : MonoBehaviour, IDropHandler
{
    public AudioSource potionDrop;
    public ParticleSystem potionDropEffect;
    [SerializeField] Image image;
    
    void Awake()
    {
        
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if(eventData.pointerDrag != null)
        {
            potionDrop.Play();
            potionDropEffect.Play();
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            image.color = ColorChange.colorChanger;
        }
    }

    public void ColorReset()
    {
        ColorChange.colorChanger = Color.black;
        image.color = ColorChange.colorChanger;
    }
}
