using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public static Color colorChanger;
    public void ColorChangery(Color colorToChange)
    {
        colorChanger = colorToChange;
    }
}
