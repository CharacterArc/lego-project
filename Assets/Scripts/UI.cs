using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject inventory;
    public GameObject chat;


    // Start is called before the first frame update
    void Start()
    {
        inventory.SetActive(true);
        chat.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {
            if (chat.activeSelf == false)
            {
                chat.SetActive(true);
            }
            else
            {
                chat.SetActive(false);
            }
        }
        if (Input.GetKeyDown("i"))
        {
            if (inventory.activeSelf == false)
            {
                inventory.SetActive(true);
            }
            else
            {
                inventory.SetActive(false);
            }
        }
    }
}
