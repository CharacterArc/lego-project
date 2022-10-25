using System.Collections;
using System.Collections.Generic;
using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Countdowntimer : MonoBehaviour
{

    float currentTime = 0f;
    float startingTime = 300f; //5 min
    int min, sec;
    string minT;
    public AudioSource potionLose;

    [SerializeField] Text countdown;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        min = Convert.ToInt32(currentTime) / 60;
        sec = Convert.ToInt32(currentTime - (min * 60));
        minT = min.ToString();
        if (currentTime >= 0)
        {
            if (sec == 0)
            {
                countdown.text = minT + ":" + "00";
            }
            else if ((currentTime % 60) == 0)
            {
                countdown.text = minT + ":" + "00";
            }
            else
            {
                if ((currentTime % 60) < 10)
                {
                    countdown.text = minT + ":" + "0" + (currentTime % 60).ToString("0");
                }
                else
                {
                    countdown.text = minT + ":" + (currentTime % 60).ToString("0");
                }
            }
        }
        else
        {
            countdown.text = "0:00";
            potionLose.Play();
        }
    }
}
