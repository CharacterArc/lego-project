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
    [SerializeField] Image LiquidImage;
    private Color ogLiquidColor;
    
    void Awake()
    {
        ogLiquidColor = LiquidImage.color;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if(eventData.pointerDrag != null)
        {
            potionDrop.Play();
            potionDropEffect.Play();
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            LiquidImage.color += GlobalVars.colorChanger;
            GlobalVars.WinCode += GlobalVars.CodeHolder;

            if (GlobalVars.WinCode != "1" || GlobalVars.WinCode != "2" || GlobalVars.WinCode != "3" || GlobalVars.WinCode != "4" || GlobalVars.WinCode != "5" || GlobalVars.WinCode != "6")
            {
                GlobalVars.dropped = true;
            }


        }
    }

    public void ColorReset()
    {
        GlobalVars.colorChanger = ogLiquidColor;
        LiquidImage.color = GlobalVars.colorChanger;
        GlobalVars.WinCode = "";
    }

    public void brewCompletion()
    {
        Debug.Log("Code: " + GlobalVars.WinCode);
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
