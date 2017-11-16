using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour
{
    private const float STRAFE = 0.1f, WALK = 0.5f, RUN = 1.0f;
    private CharacterController controller;
    private Animator animator;
    private Vector3 movement;
    private float deltaX, deltaZ, yaw, animationSpeed, currentAnimation = 0.0f, animationVelocity = 0.0f;
    private bool isRunning = false;

    public float gravity = 9.8f, speed = 3.0f, rotationSpeed = 90.0f, animationSmoothing = 0.3f;

    // Use this for initialization
    void Start ()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        deltaX = Input.GetAxis("Horizontal");
        deltaZ = Input.GetAxis("Vertical");
        isRunning = Input.GetKey(KeyCode.LeftShift);

        // Character rotation
        yaw += deltaX * rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, yaw, 0);

        // Character movement
        movement = new Vector3(0, 0, deltaZ);
        movement = transform.TransformDirection(movement);
        movement *= isRunning ? speed * 2 : speed;
        movement.y -= gravity;
        movement *= Time.deltaTime;
        controller.Move(movement);

        // Animation
        if (deltaZ == 0 && deltaX != 0) animationSpeed = STRAFE;
        else if (deltaZ != 0 && isRunning) animationSpeed = RUN;
        else if (deltaZ != 0) animationSpeed = WALK;
        else animationSpeed = 0;

        currentAnimation = Mathf.SmoothDamp(currentAnimation, animationSpeed, ref animationVelocity, animationSmoothing, Mathf.Infinity, Time.deltaTime);
        animator.SetFloat("animationSpeed", currentAnimation);
    }
}
