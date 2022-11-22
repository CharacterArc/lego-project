using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;

    
    [SerializeField]
    private LayerMask mask;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerMove>().playerCamera;
       
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
