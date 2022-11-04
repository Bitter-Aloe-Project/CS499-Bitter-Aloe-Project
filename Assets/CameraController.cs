using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class CameraController : MonoBehaviour
{

    // EDITOR VARS
    public float walkSpeed  = 7.5f;
    public float jumpSpeed  = 8.0f;
    public float gravity    = 20.0f;
    public float lookSpeed  = 2.0f;
    public float lookXLimit = 45.0f;
    public Camera playerCam;

    // CONTROLLER VARS
    CharacterController charController;
    Vector3 moveDir = Vector3.zero;
    float rotX = 0.0f;

    // GAME STATE METHODS

    // Called once on initialization
    void Start() 
    {
        charController = GetComponent<CharacterController>();
        
        Cursor.lockState  = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Once Every Frame
    void Update()
    {  
        MouseAiming();
        KeyboardMovement();
    }

    // GAME LOGIC METHODS

    // Respond to mouse input
    void MouseAiming()
    {
        rotX += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotX = Mathf.Clamp(rotX, -lookXLimit, lookXLimit);
        playerCam.transform.localRotation = Quaternion.Euler(rotX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
    }

    // Respond to  keyboard input
    void KeyboardMovement ()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right   = transform.TransformDirection(Vector3.right);

        float speedX    = walkSpeed * Input.GetAxis("Vertical");
        float speedY    = walkSpeed * Input.GetAxis("Horizontal");
        float moveDirY  = moveDir.y;

        // Calculate basic move direction and magnitude
        moveDir   = (forward * speedX) + (right * speedY);
        // Apply jump force if valid
        moveDir.y = (Input.GetButton("Jump") && charController.isGrounded) ?  jumpSpeed : moveDirY;
        // Apply gravity if valid
        moveDir.y = (!charController.isGrounded) ?  moveDir.y - (gravity * Time.deltaTime) : moveDir.y;

        charController.Move(moveDir * Time.deltaTime); 
    }
}
