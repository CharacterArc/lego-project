using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatBuild : Interactable
{
    [SerializeField]
    private LayerMask mask;
    // Start is called before the first frame update
    void Start()
    {
        promptMessage = "Place Cat Here :)";
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(this.transform.position, this.transform.up);
        Debug.DrawRay(ray.origin, ray.direction * 10f);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, 10f, mask))
        {
            if(Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.collider.gameObject.tag == "cat(Clone)")
                {
                    print("kitty");
                    correct();
                }
                else
                {
                    wrong();
                }

            }
        }

    }

    protected override void Interact()
    {
        print("hi");
    }
}
