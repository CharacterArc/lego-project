using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notes : MonoBehaviour
{
    [SerializeField] private Text txt;
    [SerializeField] private Image back;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") back.enabled = true;
        if (col.gameObject.tag == "Player") txt.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player") txt.enabled = false;
        if (col.gameObject.tag == "Player") back.enabled = false;
    }

}
