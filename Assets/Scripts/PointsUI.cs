using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsUI : MonoBehaviour
{
    public int allPoints = 0;
    [SerializeField]
    private TextMeshProUGUI pointsText;

    // Update is called once per frame
    public void Update()
    {
        int currentPoints = 0;
        Interactable[] checkPoints = FindObjectsOfType<Interactable>();
        for(int i=0; i<checkPoints.Length; i++)
        {
            currentPoints = checkPoints[i].points + currentPoints;
        }
        allPoints = currentPoints;
        pointsText.text = "Points: " + allPoints + "/7";
    }
}