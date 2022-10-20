using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{

    [SerializeField]
    private Camera playerCamera;

    private bool buildModeOn = false;
    private bool canBuild = false;

    private BlockSystem bSys;

    [SerializeField]
    private LayerMask buildableSurfacesLayer;

    private Vector3 buildPos;

    private GameObject currentTemplateBlock;

    [SerializeField]
    private GameObject blockTemplatePrefab;
    [SerializeField]
    private GameObject blockPrefab;

    [SerializeField]
    private Material templateMaterial;

    private int blockSelectCounter = 0;

    private void Start()
    {
        bSys = GetComponent<BlockSystem>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            buildModeOn = !buildModeOn;

            if (buildModeOn)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (Input.GetKeyDown("r"))
        {
            blockSelectCounter++;
            if (blockSelectCounter >= bSys.allBlocks.Count) blockSelectCounter = 0;
        }

        if (buildModeOn)
        {
            RaycastHit buildPosHit;
            

            if (Physics.Raycast(playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out buildPosHit, 10, buildableSurfacesLayer))
            {
                Vector3 point = buildPosHit.point;
                Vector3 normal = buildPosHit.normal;
                if (buildPosHit.transform.tag == "BrickPlaced")
                {
                    buildPos = new Vector3(Mathf.Round(point.x + normal.x / 2), buildPosHit.collider.transform.position.y +1.2f, Mathf.Round(point.z + normal.z / 2));
                }
                else
                {
                    buildPos = new Vector3(Mathf.Round(point.x), Mathf.Round(point.y), Mathf.Round(point.z));
                }
                canBuild = true;
            }
            else
            {
                Destroy(currentTemplateBlock.gameObject);
                canBuild = false;
            }
        }

        if (!buildModeOn && currentTemplateBlock != null)
        {
            Destroy(currentTemplateBlock.gameObject);
            canBuild = false;
        }

        if (canBuild && currentTemplateBlock == null)
        {
            currentTemplateBlock = Instantiate(blockTemplatePrefab, buildPos, Quaternion.identity);
            currentTemplateBlock.GetComponent<MeshRenderer>().material = templateMaterial;
        }

        if (canBuild && currentTemplateBlock != null)
        {
            currentTemplateBlock.transform.position = buildPos;

            if (Input.GetMouseButtonDown(0))
            {
                PlaceBlock();
            }
            if(Input.GetMouseButtonDown(1))
            {
                DestroyBlock();
            }
        }
    }

    private void PlaceBlock()
    {
        GameObject newBlock = Instantiate(blockPrefab, buildPos, Quaternion.identity);
        Block tempBlock = bSys.allBlocks[blockSelectCounter];
        newBlock.name = tempBlock.blockName + "-Block";
        newBlock.GetComponent<MeshRenderer>().material = tempBlock.blockMaterial;
    }
    void DestroyBlock()
    {
        RaycastHit pos;

        if (Physics.Raycast(playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out pos, 10))
        {
            if(pos.transform.tag == "BrickPlaced")
                Destroy(pos.transform.gameObject);
        }
    }
}