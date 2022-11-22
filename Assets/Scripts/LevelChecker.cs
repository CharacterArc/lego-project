using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelChecker : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI gameEnd;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            CheckIfAllTrue();
        }
        
    }

    public bool CheckIfAllTrue()
    {
        Interactable[] bricks = FindObjectsOfType<Interactable>();
        for(int i=0; i<bricks.Length; i++)
        {
            if(gameObject.GetComponent<PointsUI>().allPoints != 7)
            {
                gameEnd.text = "Not Enough Blocks";
                return false;
            }
        }
        gameEnd.text = "You Win!";
        return true;
        
    }
    
}
