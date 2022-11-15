using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVars : MonoBehaviour
{
    public static Color colorChanger;                   //passed to dropslot for color change
    public static string CodeHolder;                       //passed from material to dropslot for wincode
    public static Sprite IngrediantSprite;              //passed from ingrediants to change the item in mortar
    public static int LevelCode = 0;                    //this updates whenever the correct combination of materials is given
    public static string WinCode = "";                  //the current set of materials in the pot
    public static string CompletionCode = "1M23";         //this is the combination of materials to win the game
    public static bool grinding = false;
    public static bool dropped = false;
    public static bool started = false;
    public void ColorChangery(Color colorToChange)
    {
        colorChanger = colorToChange;
    }

    public static void LevelUp()              //this triggers every time a brew is successful
    {
        LevelCode++;
        switch (LevelCode)
        {
            case 0:
                CompletionCode = "1M23";
                break;
            case 1:
                CompletionCode = "C4F5C6";
                break;
            case 2:
                CompletionCode = "123456";
                break;
            case 3:
                CompletionCode = "123";
                break;
            default:
                CompletionCode = "123";
                break;
        }
    }
}
