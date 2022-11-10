using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class Interactable : MonoBehaviour
{

    public string promptMessage;
    public bool condition = true;

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
        condition = true;
        print("Winning");
    }

    public void wrong()
    {
        condition = false;
        print("Losing");
    }

}
