using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float backwardSpeedMultiplier = 0.5f; // Slower speed when moving backward
    private float currentSpeed;
    private Vector2 moveInput;
    private CharacterController controller;
    private PlayerInput playerInput;
    private bool isRunning;

    // Expose the isRunning flag as a public property
    public bool IsRunning => isRunning;

    // Event for animation updates
    public delegate void OnMoveEvent(float xSpeed, float ySpeed);
    public event OnMoveEvent OnMoveEventTriggered;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        playerInput.actions["Move"].performed += Move;
        playerInput.actions["Move"].canceled += Move;
        playerInput.actions["Run"].performed += Run;
        playerInput.actions["Run"].canceled += Run;
    }

    private void OnDisable()
    {
        playerInput.actions["Move"].performed -= Move;
        playerInput.actions["Move"].canceled -= Move;
        playerInput.actions["Run"].performed -= Run;
        playerInput.actions["Run"].canceled -= Run;
    }

    private void Move(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        UpdateMovement();
    }

    private void Run(InputAction.CallbackContext context)
    {
        isRunning = context.ReadValueAsButton();
        UpdateMovement(); // Explicitly update movement when run state changes
    }

    private void UpdateMovement()
    {
        // Calculate speed based on movement direction and run state
        float speed = isRunning ? runSpeed : walkSpeed;

        // Apply backward speed multiplier if moving backward (S key)
        if (moveInput.y < 0)
        {
            speed *= backwardSpeedMultiplier;
        }

        currentSpeed = speed;

        // Convert moveInput to proper blend tree values
        float xSpeed = moveInput.x;
        float ySpeed = moveInput.y;

        // Scale XSpeed and YSpeed for running
        if (isRunning)
        {
            xSpeed *= 2; // Double the XSpeed for running
            ySpeed *= 2; // Double the YSpeed for running
        }

        // Invoke event to update animations
        OnMoveEventTriggered?.Invoke(xSpeed, ySpeed);
    }

    private void Update()
    {
        Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y).normalized;

        if (moveDirection.magnitude > 0.1f)
        {
            Vector3 move = transform.forward * moveDirection.z + transform.right * moveDirection.x;
            controller.Move(move * currentSpeed * Time.deltaTime);
        }
    }
}