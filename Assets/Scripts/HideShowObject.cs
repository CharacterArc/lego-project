using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideShowObject : MonoBehaviour
{
    public GameObject obj;

    public void hide()
    {
        obj.SetActive(false);
    }
    public void show()
    {
        obj.SetActive(true);
    }

}
