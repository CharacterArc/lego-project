using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class Mortar : MonoBehaviour, IDropHandler
{
    public Image HeldIngrediant;
    private Sprite EmptyMortar;
    public static string ItemCode = "";
    public static int TimesGrinded;
    private Color MortorColor;
    public static bool onMortar = false;
    [SerializeField] Text texture;
    [SerializeField] AudioSource MortarDrop;
    [SerializeField] AudioSource GrindNoise;

    public void Awake()
    {
        EmptyMortar = HeldIngrediant.sprite;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null)
        {
            MortarDrop.Play();
            TimesGrinded = 0;
            texture.text = "";
            HeldIngrediant.sprite = GlobalVars.IngrediantSprite;
            ItemCode = GlobalVars.CodeHolder;
            MortorColor = GlobalVars.colorChanger;
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public void Grind()
    {
        if (ItemCode != "")
        {
            TimesGrinded++;
            GrindNoise.Play();
            if (TimesGrinded >= 1 && TimesGrinded < 5)
            {
                texture.text = "Texture: Coarse";
            }
            else if (TimesGrinded >= 5 && TimesGrinded < 10)
            {
                texture.text = "Texture: Medium";
            }
            else if (TimesGrinded >= 10)
            {
                texture.text = "Texture: Fine";
            }
        }
        else
        {
            texture.text = "No ingrediant!";
        }
    }
    public void MortarReset()
    {
        TimesGrinded = 0;
        texture.text = "";
        HeldIngrediant.sprite = EmptyMortar;
        ItemCode = "";
    }
}
