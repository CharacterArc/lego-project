using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// 
public class Interactable : MonoBehaviour
{
    public int points = 0;
    public string promptMessage;
    public bool condition = false;
    public LayerMask mask;
    public TextMeshProUGUI popText;



    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //nothing here
    }
    public void correct()
    {
        points = 1;
        condition = true;
        print("Winning");
    }

    public void wrong()
    {
        points = 0;
        condition = false;
        print("Losing");
    }

    public IEnumerator ShowMessage()
    {
        popText.text = "Wrong Block";
        popText.enabled = true;
        yield return new WaitForSeconds(1);
        popText.enabled = false;
    }

}
