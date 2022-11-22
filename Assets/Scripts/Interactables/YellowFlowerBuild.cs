using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowFlowerBuild : Interactable
{

    // Start is called before the first frame update
    void Start()
    {
        mask = LayerMask.GetMask("Build");
        promptMessage = "Place Yellow Flower Here :)";
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
                if(hitInfo.collider.gameObject.tag == "yellowFlower(Clone)")
                {
                    correct();
                }
                else
                {
                    wrong();
                    Destroy(hitInfo.transform.gameObject);
                    StartCoroutine(ShowMessage());
                }
            }
            else
            {
                wrong();
            }
        }
        else
        {
            wrong();
        }

    }

    protected override void Interact()
    {
        print("hi");
    }
}
