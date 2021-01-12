using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;
public class ThirdPersonController : MonoBehaviour
{

    public CharacterController controller;
    public Transform camera;

    public float speed = 10;

    private Vector2 moveInput;
    private Vector3 inputDirection;

    private Vector3 movementDirection;
    // Vector3 movementDirection;

    private float smoothTime = 0.1f;
    private float smoothVeloctiy;

    public float gravity = 0.2f;
    public float Jumpforce = 0.3f;

    public float fallMultiplier = 1.5f;
    public float lowMultiplier = 1f;
    
    //used so the jump force will be remembered next frame
    private float directionY;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMovement();
    }

    void UpdateMovement()
    {
        movementDirection = Vector3.zero;
        if (moveInput.magnitude > 0.1f)
        {
            float targetAngle = Mathf.Atan2(-inputDirection.z, inputDirection.x) * Mathf.Rad2Deg + camera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle-90, ref smoothVeloctiy, smoothTime);
            transform.rotation = Quaternion.Euler(0,angle,0);
            movementDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward * moveInput.magnitude;
        }
        
        
        directionY -= gravity * Time.deltaTime;

        movementDirection.y = directionY;
        
        controller.Move(movementDirection * speed * Time.deltaTime);
    }

    public void OnJump()
    {
        if (controller.isGrounded)
        {
            directionY = Jumpforce;
        }
    }

    public void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
        inputDirection = new Vector3(moveInput.y,0,-moveInput.x).normalized;
    }
}
  