using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    public Color ColorBase;
    public int ItemCode;
    private GlobalVars ColorChoice;
    private RectTransform rectTransform;
    private Vector3 origPos;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup =  GetComponent<CanvasGroup>();
        origPos = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = .75f;
        canvasGroup.blocksRaycasts = false;
        GlobalVars.colorChanger = ColorBase;
        GlobalVars.CodeHolder = ItemCode;
    }
    public void OnDrag(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
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
}
