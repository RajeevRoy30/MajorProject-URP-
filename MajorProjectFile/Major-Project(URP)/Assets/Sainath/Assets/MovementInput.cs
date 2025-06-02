
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

////This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
////With a blend tree to control the inputmagnitude and allow blending between animations.
//[RequireComponent(typeof(CharacterController))]
//public class MovementInput : MonoBehaviour {

//	public float InputX;
//	public float InputZ;
//	public Vector3 desiredMoveDirection;
//	public bool blockRotationPlayer;
//	public float desiredRotationSpeed = 0.1f;
//	public Animator anim;
//	public float Speed;
//	public float allowPlayerRotation = 0.1f;
//	public Camera cam;
//	public CharacterController controller;
//	public bool isGrounded;

//    [Header("Animation Smoothing")]
//    [Range(0, 1f)]
//    public float HorizontalAnimSmoothTime = 0.2f;
//    [Range(0, 1f)]
//    public float VerticalAnimTime = 0.2f;
//    [Range(0,1f)]
//    public float StartAnimTime = 0.3f;
//    [Range(0, 1f)]
//    public float StopAnimTime = 0.15f;


//    private float verticalVel;
//    private Vector3 moveVector;

//	// Use this for initialization
//	void Start () {
//		anim = this.GetComponent<Animator> ();
//		cam = Camera.main;
//		controller = this.GetComponent<CharacterController> ();
//	}

//	// Update is called once per frame
//	void Update () {
//		anim.SetBool("Run",Input.GetKey(KeyCode.LeftShift));
//		InputMagnitude ();
//        /*
//		//If you don't need the character grounded then get rid of this part.
//		isGrounded = controller.isGrounded;
//		if (isGrounded) {
//			verticalVel -= 0;
//		} else {
//			verticalVel -= 2;
//		}
//		moveVector = new Vector3 (0, verticalVel, 0);
//		controller.Move (moveVector);
//        */
//		//Updater
//	}

//	void PlayerMoveAndRotation() {
//		InputX = Input.GetAxis ("Horizontal");
//		InputZ = Input.GetAxis ("Vertical");

//		var camera = Camera.main;
//		var forward = cam.transform.forward;
//		var right = cam.transform.right;

//		forward.y = 0f;
//		right.y = 0f;

//		forward.Normalize ();
//		right.Normalize ();

//		desiredMoveDirection = forward * InputZ + right * InputX;

//        if (GetComponent<ThrowController>().aiming)
//            return;

//		if (blockRotationPlayer == false) {
//			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);
//            controller.Move(desiredMoveDirection * Time.deltaTime * 3);
//		}
//	}

//    public void RotateToCamera(Transform t)
//    {

//        var camera = Camera.main;
//        var forward = cam.transform.forward;
//        var right = cam.transform.right;

//        desiredMoveDirection = forward;

//        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
//    }

//	void InputMagnitude() {
//		//Calculate Input Vectors
//		InputX = Input.GetAxis ("Horizontal");
//		InputZ = Input.GetAxis ("Vertical");

//		//anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
//		//anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

//		//Calculate the Input Magnitude
//		Speed = new Vector2(InputX, InputZ).sqrMagnitude;

//		//Physically move player
//		if (Speed > allowPlayerRotation) {
//			//anim.SetFloat ("InputMagnitude", Speed, StartAnimTime, Time.deltaTime);
//			PlayerMoveAndRotation ();
//		} else if (Speed < allowPlayerRotation) {
//			//anim.SetFloat ("InputMagnitude", Speed, StopAnimTime, Time.deltaTime);
//		}
//	}
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script requires an animator with parameters: "InputMagnitude", "InputX", "InputZ"
// Ensure you have a blend tree controlling movement animations.
//[RequireComponent(typeof(CharacterController))]
//public class MovementInput : MonoBehaviour
//{
//    public float InputX;
//    public float InputZ;
//    public Vector3 desiredMoveDirection;
//    public bool blockRotationPlayer;
//    public float desiredRotationSpeed = 0.1f;
//    public Animator anim;
//    public float Speed;
//    public float allowPlayerRotation = 0.1f;
//    public Camera cam;
//    public CharacterController controller;
//    public bool isGrounded;

//    [Header("Movement Speeds")]
//    public float walkSpeed = 2f;
//    public float runSpeed = 5f;
//    private float currentSpeed;

//    [Header("Animation Smoothing")]
//    [Range(0, 1f)]
//    public float HorizontalAnimSmoothTime = 0.2f;
//    [Range(0, 1f)]
//    public float VerticalAnimTime = 0.2f;
//    [Range(0, 1f)]
//    public float StartAnimTime = 0.3f;
//    [Range(0, 1f)]
//    public float StopAnimTime = 0.15f;

//    private float verticalVel;
//    private Vector3 moveVector;

//    // Initialization
//    void Start()
//    {
//        anim = GetComponent<Animator>();
//        cam = Camera.main;
//        controller = GetComponent<CharacterController>();
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        bool isRunning = Input.GetKey(KeyCode.LeftShift);
//        anim.SetBool("Run", isRunning);

//        // Adjust current speed based on run or walk
//        currentSpeed = isRunning ? runSpeed : walkSpeed;

//        InputMagnitude();
//    }

//    void PlayerMoveAndRotation()
//    {
//        InputX = Input.GetAxis("Horizontal");
//        InputZ = Input.GetAxis("Vertical");

//        var forward = cam.transform.forward;
//        var right = cam.transform.right;

//        forward.y = 0f;
//        right.y = 0f;

//        forward.Normalize();
//        right.Normalize();

//        desiredMoveDirection = forward * InputZ + right * InputX;

//        if (GetComponent<ThrowController>()?.aiming == true)
//            return;

//        if (!blockRotationPlayer)
//        {
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
//            controller.Move(desiredMoveDirection * Time.deltaTime * currentSpeed);
//        }
//    }

//    public void RotateToCamera(Transform t)
//    {
//        var forward = cam.transform.forward;
//        desiredMoveDirection = forward;

//        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
//    }

//    void InputMagnitude()
//    {
//        // Get input values
//        InputX = Input.GetAxis("Horizontal");
//        InputZ = Input.GetAxis("Vertical");

//        // Calculate input magnitude
//        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

//        // Move player if input magnitude is greater than allowed rotation threshold
//        if (Speed > allowPlayerRotation)
//        {
//            anim.SetFloat("InputMagnitude", Speed, StartAnimTime, Time.deltaTime);
//            PlayerMoveAndRotation();
//        }
//        else
//        {
//            anim.SetFloat("InputMagnitude", Speed, StopAnimTime, Time.deltaTime);
//        }
//    }
//}
//[RequireComponent(typeof(CharacterController))]
//public class MovementInput : MonoBehaviour
//{
//    public float InputX;
//    public float InputZ;
//    public Vector3 desiredMoveDirection;
//    public bool blockRotationPlayer;
//    public float desiredRotationSpeed = 0.1f;
//    public Animator anim;
//    public float Speed;
//    public float allowPlayerRotation = 0.1f;
//    public Camera cam;
//    public CharacterController controller;
//    public bool isGrounded;

//    [Header("Movement Speeds")]
//    public float walkSpeed = 2f;
//    public float runSpeed = 5f;
//    private float currentSpeed;

//    [Header("Gravity Settings")]
//    public float gravity = -9.81f;
//    public float groundedOffset = -0.1f;
//    public float groundedCheckRadius = 0.3f;
//    public LayerMask groundLayers;
//    public Transform groundCheck;

//    [Header("Animation Smoothing")]
//    [Range(0, 1f)]
//    public float HorizontalAnimSmoothTime = 0.2f;
//    [Range(0, 1f)]
//    public float VerticalAnimTime = 0.2f;
//    [Range(0, 1f)]
//    public float StartAnimTime = 0.3f;
//    [Range(0, 1f)]
//    public float StopAnimTime = 0.15f;

//    private float verticalVel;
//    private Vector3 moveVector;

//    void Start()
//    {
//        anim = GetComponent<Animator>();
//        cam = Camera.main;
//        controller = GetComponent<CharacterController>();
//    }

//    void Update()
//    {
//        isGrounded = Physics.CheckSphere(groundCheck.position, groundedCheckRadius, groundLayers, QueryTriggerInteraction.Ignore);

//        if (isGrounded && verticalVel < 0)
//        {
//            verticalVel = -2f; // Small downward force to keep grounded
//        }
//        else
//        {
//            verticalVel += gravity * Time.deltaTime;
//        }

//        bool isRunning = Input.GetKey(KeyCode.LeftShift);
//        anim.SetBool("Run", isRunning);

//        currentSpeed = isRunning ? runSpeed : walkSpeed;

//        InputMagnitude();
//    }

//    void PlayerMoveAndRotation()
//    {
//        InputX = Input.GetAxis("Horizontal");
//        InputZ = Input.GetAxis("Vertical");

//        var forward = cam.transform.forward;
//        var right = cam.transform.right;

//        forward.y = 0f;
//        right.y = 0f;

//        forward.Normalize();
//        right.Normalize();

//        desiredMoveDirection = forward * InputZ + right * InputX;

//        if (GetComponent<ThrowController>()?.aiming == true)
//            return;

//        if (!blockRotationPlayer)
//        {
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
//        }

//        // Apply movement with gravity
//        moveVector = desiredMoveDirection * currentSpeed;
//        moveVector.y = verticalVel;

//        controller.Move(moveVector * Time.deltaTime);
//    }

//    public void RotateToCamera(Transform t)
//    {
//        var forward = cam.transform.forward;
//        desiredMoveDirection = forward;

//        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
//    }

//    void InputMagnitude()
//    {
//        InputX = Input.GetAxis("Horizontal");
//        InputZ = Input.GetAxis("Vertical");

//        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

//        if (Speed > allowPlayerRotation)
//        {
//            anim.SetFloat("InputMagnitude", Speed, StartAnimTime, Time.deltaTime);
//            PlayerMoveAndRotation();
//        }
//        else
//        {
//            anim.SetFloat("InputMagnitude", Speed, StopAnimTime, Time.deltaTime);
//            // Still apply gravity when idle
//            moveVector = new Vector3(0, verticalVel, 0);
//            controller.Move(moveVector * Time.deltaTime);
//        }
//    }
//}
//using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
//public class MovementInput : MonoBehaviour
//{
//    public float InputX;
//    public float InputZ;
//    public Vector3 desiredMoveDirection;
//    public bool blockRotationPlayer;
//    public float desiredRotationSpeed = 0.1f;
//    public Animator anim;
//    public float Speed;
//    public float allowPlayerRotation = 0.1f;
//    public Camera cam;
//    public CharacterController controller;

//    [Header("Movement Speeds")]
//    public float walkSpeed = 2f;
//    public float runSpeed = 5f;
//    private float currentSpeed;

//    [Header("Gravity Settings")]
//    public float gravity = -9.81f;
//    public float groundedCheckRadius = 0.3f;
//    public LayerMask groundLayers;
//    public Transform groundCheck;
//    private float verticalVel;
//    private bool isGrounded;
//    private Vector3 moveVector;

//    [Header("Animation Smoothing")]
//    [Range(0, 1f)] public float HorizontalAnimSmoothTime = 0.2f;
//    [Range(0, 1f)] public float VerticalAnimTime = 0.2f;
//    [Range(0, 1f)] public float StartAnimTime = 0.3f;
//    [Range(0, 1f)] public float StopAnimTime = 0.15f;

//    void Start()
//    {
//        anim = GetComponent<Animator>();
//        cam = Camera.main;
//        controller = GetComponent<CharacterController>();
//    }

//    void Update()
//    {
//        // Ground check using a sphere
//        isGrounded = Physics.CheckSphere(groundCheck.position, groundedCheckRadius, groundLayers, QueryTriggerInteraction.Ignore);

//        if (isGrounded && verticalVel < 0)
//        {
//            verticalVel = -2f; // Small force to keep player grounded
//        }
//        else
//        {
//            verticalVel += gravity * Time.deltaTime;
//        }

//        bool isRunning = Input.GetKey(KeyCode.LeftShift);
//        anim.SetBool("Run", isRunning);

//        currentSpeed = isRunning ? runSpeed : walkSpeed;

//        InputMagnitude();
//    }

//    void PlayerMoveAndRotation()
//    {
//        InputX = Input.GetAxis("Horizontal");
//        InputZ = Input.GetAxis("Vertical");

//        var forward = cam.transform.forward;
//        var right = cam.transform.right;

//        forward.y = 0f;
//        right.y = 0f;

//        forward.Normalize();
//        right.Normalize();

//        desiredMoveDirection = forward * InputZ + right * InputX;

//        if (GetComponent<ThrowController>()?.aiming == true)
//            return;

//        if (!blockRotationPlayer && desiredMoveDirection != Vector3.zero)
//        {
//            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
//        }

//        // Apply final movement with gravity
//        moveVector = desiredMoveDirection * currentSpeed;
//        moveVector.y = verticalVel;

//        controller.Move(moveVector * Time.deltaTime);
//    }

//    public void RotateToCamera(Transform t)
//    {
//        var forward = cam.transform.forward;
//        forward.y = 0;
//        desiredMoveDirection = forward;

//        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
//    }

//    void InputMagnitude()
//    {
//        InputX = Input.GetAxis("Horizontal");
//        InputZ = Input.GetAxis("Vertical");

//        Speed = new Vector2(InputX, InputZ).sqrMagnitude;

//        if (Speed > allowPlayerRotation)
//        {
//            anim.SetFloat("InputMagnitude", Speed, StartAnimTime, Time.deltaTime);
//            PlayerMoveAndRotation();
//        }
//        else
//        {
//            anim.SetFloat("InputMagnitude", Speed, StopAnimTime, Time.deltaTime);

//            // Apply gravity even when idle
//            moveVector = new Vector3(0, verticalVel, 0);
//            controller.Move(moveVector * Time.deltaTime);
//        }
//    }

//    void OnDrawGizmosSelected()
//    {
//        if (groundCheck != null)
//        {
//            Gizmos.color = Color.green;
//            Gizmos.DrawWireSphere(groundCheck.position, groundedCheckRadius);
//        }
//    }
//}
//using UnityEngine;

//[RequireComponent(typeof(CharacterController))]
//public class MovementInput : MonoBehaviour
//{
//    public float walkSpeed = 2f;
//    public float runSpeed = 5f;
//    public float gravity = -9.81f;
//    public float groundedCheckRadius = 0.3f;
//    public LayerMask groundLayers;
//    public Transform groundCheck;

//    private CharacterController controller;
//    private Vector3 moveDirection;
//    private float verticalVel;
//    private bool isGrounded;
//    private Camera cam;

//    void Start()
//    {
//        controller = GetComponent<CharacterController>();
//        cam = Camera.main;
//    }

//    void Update()
//    {
//        isGrounded = Physics.CheckSphere(groundCheck.position, groundedCheckRadius, groundLayers, QueryTriggerInteraction.Ignore);

//        if (isGrounded && verticalVel < 0)
//            verticalVel = -2f;
//        else
//            verticalVel += gravity * Time.deltaTime;

//        float inputX = Input.GetAxis("Horizontal");
//        float inputZ = Input.GetAxis("Vertical");

//        Vector3 forward = cam.transform.forward;
//        Vector3 right = cam.transform.right;
//        forward.y = 0;
//        right.y = 0;
//        forward.Normalize();
//        right.Normalize();

//        Vector3 move = (forward * inputZ + right * inputX).normalized;

//        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
//        moveDirection = move * speed;
//        moveDirection.y = verticalVel;

//        controller.Move(moveDirection * Time.deltaTime);
//    }

//    void OnDrawGizmosSelected()
//    {
//        if (groundCheck != null)
//        {
//            Gizmos.color = Color.green;
//            Gizmos.DrawWireSphere(groundCheck.position, groundedCheckRadius);
//        }
//    }
//}
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

    private float verticalVel;
    private Vector3 moveVector;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0, 1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;

<<<<<<< Updated upstream
    private float verticalVel;
    private Vector3 moveVector;
    private Rigidbody rb;
    private float gravity = -9.81f;
    [SerializeField] private int mass;

    // Initialization
=======
>>>>>>> Stashed changes
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundedCheckRadius, groundLayers, QueryTriggerInteraction.Ignore);

        // Gravity
        if (isGrounded && verticalVel < 0)
        {
            verticalVel = -2f;
        }
        else
        {
            verticalVel += gravity * Time.deltaTime;
        }

        bool isRunning = Input.GetKey(KeyCode.LeftShift);
        anim.SetBool("Run", isRunning);

        currentSpeed = isRunning ? runSpeed : walkSpeed;

        InputMagnitude();
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (GetComponent<ThrowController>()?.aiming == true)
            return;

<<<<<<< Updated upstream

        //if (controller.isGrounded && desiredMoveDirection.y < 0)
        //{
        //    rb.AddForce(new Vector3(0, -2, 0));
        //    //desiredMoveDirection.y = -2f; // Keeps player "stuck" to ground
        //}
        if(!controller.isGrounded)
        {
            rb.AddForce(new Vector3 (0,gravity*mass,0)*Time.deltaTime);
           //desiredMoveDirection.y += gravity * mass * Time.deltaTime;
        }


        if (!blockRotationPlayer)
=======
        if (!blockRotationPlayer && desiredMoveDirection != Vector3.zero)
>>>>>>> Stashed changes
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        }

<<<<<<< Updated upstream
=======
        moveVector = desiredMoveDirection * currentSpeed;
        moveVector.y = verticalVel;

        controller.Move(moveVector * Time.deltaTime);
>>>>>>> Stashed changes
    }

    public void RotateToCamera(Transform t)
    {
        var forward = cam.transform.forward;
        forward.y = 0;
        desiredMoveDirection = forward;

        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
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

            // Apply vertical motion only (gravity) when idle
            moveVector = new Vector3(0, verticalVel, 0);
            controller.Move(moveVector * Time.deltaTime);
        }
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
