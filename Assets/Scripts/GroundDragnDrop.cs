using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Image = UnityEngine.UI.Image;

public class GroundDragnDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private Color ColorBase;
    public Image GroundImage;
    public Sprite EmptyMortar;
    private string ItemCode = "";
    private string ItemType = "";
    private RectTransform rectTransform;
    private Vector3 origPos;
    private CanvasGroup canvasGroup;
    public Sprite CoarseIngrediant;
    public Sprite MediumIngrediant;
    public Sprite FineIngrediant;
    public Sprite Blank;

    private void Awake()
    {
        EmptyMortar = GroundImage.sprite;
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        origPos = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Mortar.TimesGrinded != 0)
        {
            //throw new System.NotImplementedException();
            Debug.Log("OnBeginDrag");
            canvasGroup.alpha = .75f;
            canvasGroup.blocksRaycasts = false;
            GlobalVars.CodeHolder = ItemType + ItemCode;
            GlobalVars.colorChanger = GroundImage.color / 5;
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        if (Mortar.TimesGrinded != 0)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        rectTransform.anchoredPosition = origPos;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnPointerDown");

    }

    public void GrindItem()
    {
        if(Mortar.TimesGrinded != 0)
        {
            GroundImage.color = GlobalVars.colorChanger*10;
            ItemCode = Mortar.ItemCode;
            if(Mortar.TimesGrinded >= 1 && Mortar.TimesGrinded < 5)
            {
                ItemType = "C";
                GroundImage.sprite = CoarseIngrediant;
            }
            else if (Mortar.TimesGrinded >= 5 && Mortar.TimesGrinded < 10)
            {
                ItemType = "M";
                GroundImage.sprite = MediumIngrediant;
            }
            else if (Mortar.TimesGrinded >= 10)
            {
                ItemType = "F";
                GroundImage.sprite = FineIngrediant;
            }
        }
    }

    public void GroundReset()
    {
        GroundImage.sprite = Blank;
        GroundImage.color = Color.white;
        ItemCode = "";
    }
}

