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
    public AudioSource potionWin;
    public AudioSource potionLose;
    public ParticleSystem potionDropEffect;
    public ParticleSystem potionWinEffect;
    public ParticleSystem potionLoseEffect;
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
        }
    }

    public void ColorReset()
    {
        GlobalVars.colorChanger = ogLiquidColor;
        image.color = GlobalVars.colorChanger;
        GlobalVars.WinCode = "";
    }

    public void brewCompletion()
    {
        if (GlobalVars.CompletionCode == GlobalVars.WinCode)
        {
            GlobalVars.LevelUp();
            //do the wins stuff
            Debug.Log("You Win!");
            potionWin.Play();
            potionWinEffect.Play();
            ColorReset();
        }
        else if(GlobalVars.WinCode != "")
        {
            //do the lose stuff
            Debug.Log("You Lose!");
            potionLose.Play();
            potionLoseEffect.Play();
            ColorReset();
        }
    }
}
