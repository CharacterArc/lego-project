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
    private Color ogLiquidColor;
    
    void Awake()
    {
        ogLiquidColor = image.color;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if(eventData.pointerDrag != null)
        {
            potionDrop.Play();
            potionDropEffect.Play();
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            image.color += GlobalVars.colorChanger;
            GlobalVars.WinCode += GlobalVars.CodeHolder.ToString();
            if (GlobalVars.CompletionCode == GlobalVars.WinCode)
            {
                //do the wins stuff
                Debug.Log("You Win!");
            }
        }
    }

    public void ColorReset()
    {
        GlobalVars.colorChanger = ogLiquidColor;
        image.color = GlobalVars.colorChanger;
        GlobalVars.WinCode = "";
    }
}
