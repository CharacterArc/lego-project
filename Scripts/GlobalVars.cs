using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public static Color colorChanger;                   //passed to dropslot for color change
    public static int CodeHolder;                       //passed from material to dropslot for wincode
    public static string WinCode = "";                  //the current set of materials in the pot
    public const string CompletionCode = "123";         //this is the combination of materials to win the game
    public void ColorChangery(Color colorToChange)
    {
        colorChanger = colorToChange;
    }
}
