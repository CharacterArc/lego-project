using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    // To setup object for this script:
    /* Create player object.
     * Child game camera to player.
     * Assign player to own layer. 
     * Remove player's layer from the camera's culling mask.
     * Add CharacterController component to player.
     * Add this script to player and set variables.
     */

    // Cam look variables.
    [SerializeField]
    private float rotSpeedX; // Mouse X sensitivity control, set in editor.
    [SerializeField]
    private float rotSpeedY; // Mouse Y sensitivity control, set in editor.

    [SerializeField]
    private float rotDamp; // Damping value for camera rotation.

    private float mY = 0f; // Mouse X.
    private float mX = 0f; // Mouse Y.

    // Player move variables.

    [SerializeField]
    private float walkSpeed; 
    [SerializeField]
    private float runSpeed; 
    private float currentSpeed;

    [SerializeField]
    private KeyCode runKey; 
    [SerializeField]
    private KeyCode upKey; 

    [SerializeField]
    private KeyCode downKey; 

    private CharacterController cc; 

    [SerializeField]
    public Camera playerCamera; 

    private void Start()
    {
        cc = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
    }

    private void LateUpdate()
    {
        // Get mouse axis.
        mX += Input.GetAxis("Mouse X") * rotSpeedX * (Time.deltaTime * rotDamp);
        mY += -Input.GetAxis("Mouse Y") * rotSpeedY * (Time.deltaTime * rotDamp);

        
        mY = Mathf.Clamp(mY, -80, 80);

        
        playerCamera.transform.localEulerAngles = new Vector3(mY, 0f, 0f);
        
        transform.eulerAngles = new Vector3(0f, mX, 0f);

        
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        float elevation=0;
        if (Input.GetKey(upKey)) elevation = 1;
        if (Input.GetKey(downKey)) elevation = -1;

        
        currentSpeed = walkSpeed;
        
        if (Input.GetKey(runKey) && Input.GetKey(KeyCode.W)) currentSpeed = runSpeed;

        
        Vector3 moveDir = (transform.right * hor) + (transform.forward * ver) + (transform.up * elevation) ;

        
        cc.Move(moveDir * currentSpeed * Time.deltaTime);

        
    }
}