using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        playerMovement.OnMoveEventTriggered += UpdateAnimation;
    }

    private void OnDisable()
    {
        playerMovement.OnMoveEventTriggered -= UpdateAnimation;
    }

    private void UpdateAnimation(float xSpeed, float ySpeed)
    {
        float deadzone = 0.1f;

        // Apply deadzone to xSpeed and ySpeed
        if (Mathf.Abs(xSpeed) < deadzone) xSpeed = 0f;
        if (Mathf.Abs(ySpeed) < deadzone) ySpeed = 0f;

#if UNITY_EDITOR
        Debug.Log($"XSpeed: {xSpeed}, YSpeed: {ySpeed}"); // Debugging values
#endif

        // Set animation parameters
        animator.SetFloat("XSpeed", xSpeed);
        animator.SetFloat("YSpeed", ySpeed);

        // Check if the player is moving
        bool isMoving = Mathf.Abs(xSpeed) > deadzone || Mathf.Abs(ySpeed) > deadzone;
        animator.SetBool("IsMoving", isMoving);

        // Update running state
        animator.SetBool("IsRunning", playerMovement.IsRunning);
    }
}