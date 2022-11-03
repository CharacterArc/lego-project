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
    public GameObject[] blockPrefab = new GameObject[8];
    private int blockSelect=1;

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

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            blockSelect = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            blockSelect = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            blockSelect = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            blockSelect = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            blockSelect = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            blockSelect = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            blockSelect = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            blockSelect = 7;
        }

        if (buildModeOn)
        {
            RaycastHit buildPosHit;
            var posCheck = false;

            if (Physics.Raycast(playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)), out buildPosHit, 10, buildableSurfacesLayer))
            {
                Vector3 point = buildPosHit.point;
                Vector3 pointObj = buildPosHit.collider.transform.position;
                if (buildPosHit.transform.tag == "BrickPlaced")
                {
                    
                    for(int i = 0; i < 10; i++)
                    {
                        Collider[] hitColliders = Physics.OverlapBox(pointObj, transform.localScale / 3, Quaternion.identity, buildableSurfacesLayer);
                        posCheck = hitColliders.Length == 0;
                        if (posCheck)
                        {
                            posCheck = true;
                            break;
                        }
                        pointObj.y += 1.2f;
                    }
                    if (posCheck)
                    {
                        buildPos = new Vector3(buildPosHit.collider.transform.position.x, pointObj.y - 1.2f, buildPosHit.collider.transform.position.z);
                        pointObj = buildPosHit.collider.transform.position;
                    }
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
        GameObject newBlock = Instantiate(blockPrefab[blockSelect], buildPos, Quaternion.identity);
        Block tempBlock = bSys.allBlocks[blockSelectCounter];
        newBlock.name = tempBlock.blockName + "-Block";
        newBlock.GetComponent<MeshRenderer>().material = tempBlock.blockMaterial;
        buildPos = Vector3.zero;
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