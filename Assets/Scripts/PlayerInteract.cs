using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 3f;
    [SerializeField]
    private LayerMask mask;
    private InstructorUI instructorUI;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerMove>().playerCamera;
        instructorUI = GetComponent<InstructorUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        instructorUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                instructorUI.UpdateText(interactable.promptMessage);
                if (Input.GetKeyDown("f"))
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
