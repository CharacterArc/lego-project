using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    public string message;
    private bool showGui = false;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") showGui = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") showGui = false;

    }

    void OnGUI()
    {
        if (showGui) GUI.Box(new Rect(0, 0, 1080, 100), message);
    }
}
