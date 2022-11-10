using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChecker : MonoBehaviour
{
    
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
            if(!bricks[i].condition)
            {
                print("Lost Game");
                return false;
            }
        }
        print("Win Game");
        return true;
        
    }
    
}
