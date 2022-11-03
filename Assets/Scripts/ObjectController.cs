using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Renderer self;
    private Color initColor;
    private void Start()
    {
        self = GetComponent<Renderer>();
        initColor = self.material.color;
    }
    private void OnMouseEnter()
    {
        self.material.color = Color.white;
    }
    private void OnMouseExit()
    {
        self.material.color = initColor;
    }
}
