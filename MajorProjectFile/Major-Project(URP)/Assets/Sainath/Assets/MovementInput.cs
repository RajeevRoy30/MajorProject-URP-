using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour
{
    public float InputX;
    public float InputZ;
    public Vector3 desiredMoveDirection;
    public bool blockRotationPlayer;
    public float desiredRotationSpeed = 0.1f;
    public Animator anim;
    public float Speed;
    public float allowPlayerRotation = 0.1f;
    public Camera cam;
    public CharacterController controller;
    public bool isGrounded;

    [Header("Movement Speeds")]
    public float walkSpeed = 2f;
    public float runSpeed = 5f;
    private float currentSpeed;

    [Header("Gravity Settings")]
    public float gravity = -9.81f;
    public float groundedCheckRadius = 0.3f;
    public LayerMask groundLayers;
    public Transform groundCheck;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

    private float verticalVel;
    private Vector3 moveVector;

    void Start()
    {
        anim = GetComponent<Animator>();
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check using a sphere
        isGrounded = Physics.CheckSphere(groundCheck.position, groundedCheckRadius, groundLayers, QueryTriggerInteraction.Ignore);

        // Reset vertical velocity when grounded
        if (isGrounded && verticalVel < 0)
        {
            verticalVel = -2f;
        }
        else
        {
            verticalVel += gravity * Time.deltaTime;
        }

        // Run/Walk toggle
        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        anim.SetBool("Run", isRunning);
        currentSpeed = isRunning ? runSpeed : walkSpeed;

        InputMagnitude();
    }

    void InputMagnitude()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

        if (Speed > allowPlayerRotation)
        {
            anim.SetFloat("InputMagnitude", Speed, StartAnimTime, Time.deltaTime);
            PlayerMoveAndRotation();
        }
        else
        {
            anim.SetFloat("InputMagnitude", Speed, StopAnimTime, Time.deltaTime);
            moveVector = new Vector3(0, verticalVel, 0);
            controller.Move(moveVector * Time.deltaTime);
        }
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        Vector3 forward = cam.transform.forward;
        Vector3 right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (GetComponent<ThrowController>()?.aiming == true)
            return;

        if (!blockRotationPlayer && desiredMoveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }

        moveVector = desiredMoveDirection * currentSpeed;
        moveVector.y = verticalVel;

        controller.Move(moveVector * Time.deltaTime);
    }

    public void RotateToCamera(Transform t)
    {
        Vector3 forward = cam.transform.forward;
        forward.y = 0;
        desiredMoveDirection = forward;
        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundedCheckRadius);
        }
    }
}
