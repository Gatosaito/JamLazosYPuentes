using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.PlayerLoop;
using Unity.VisualScripting;

public class Move_Paco : MonoBehaviour
{
    public float movementSpeed;
    public float baseSpeed;
    public float sprintSpeed;
    public float shiftSpeed;
    public float mouseSensitivity;
    public float smoothRotation;

    public float velocidadRetroceder;

    public float BalanceoSpeed = 1f;
    public float BalanceoIntensity = 0.1f;

    private Camera playerCamera;
    private CharacterController characterController;
    private float verticalRotation = 0f;

    [SerializeField] private Transform pointOfView;
    [SerializeField] public Rigidbody rd;

    public Vector3 direction;
    public Vector2 mouseinput;
    public Vector3 Movement;

    private bool isWalking = false;

    public Animator animator;

    int movXAnimatorBlendTree;
    int movZAnimatorBlendTree;

    void Start()
    {
        movementSpeed = baseSpeed;
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera = GetComponentInChildren<Camera>();
        characterController = GetComponent<CharacterController>();
        rd = GetComponent<Rigidbody>();
        animator.SetFloat("MoveX", 1f);
        
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
        movXAnimatorBlendTree = Animator.StringToHash("MovX");
        movZAnimatorBlendTree = Animator.StringToHash("MovZ"); // Maldita variable mas dificil de acceder
                                                               // pero sumamente importante
                                                               // Esto sirve para modificar desde codigo la variable del blend tree -D
    }

    private void Update()
    {
        float moveInput = Mathf.Abs(Input.GetAxisRaw("Horizontal")) + Mathf.Abs(Input.GetAxisRaw("Vertical"));
        isWalking = moveInput > 0f;

        animator.SetFloat(movXAnimatorBlendTree, Input.GetAxisRaw("Horizontal"));
        animator.SetFloat(movZAnimatorBlendTree, Input.GetAxisRaw("Vertical"));
    }

    private void FixedUpdate()
    {
        // Movimiento

        float currentSpeed = isWalking ? (movementSpeed * 0.5f) : movementSpeed;

        characterController.Move(Movement * (currentSpeed * Time.deltaTime));

        direction = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        float VelY = Movement.y;
        Movement = ((transform.forward * direction.z) + (transform.right * direction.x)).normalized;
        Movement.y = VelY;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = shiftSpeed;
        }
        else
        {
            movementSpeed = baseSpeed;
        }

        characterController.Move(Movement * (movementSpeed * Time.deltaTime));

        if (isWalking)
        {
            float swayAmountX = Mathf.Sin(Time.time * BalanceoSpeed) * BalanceoIntensity;
            float swayAmountZ = Mathf.Cos(Time.time * BalanceoSpeed) * BalanceoIntensity;

            playerCamera.transform.localRotation *= Quaternion.Euler(swayAmountX, 0f, swayAmountZ);
        }
        /*
         * Creo que esto no lo necesitamos, no lo voy a borrar por si acaso lo necesita - D
        if (!isWalking)
        {
            animator.SetBool("caminar_Atras", false);
            animator.SetBool("Correr", false);
            animator.SetBool("Idle", true);
        }
        else if (Input.GetAxisRaw("Vertical") > 0f)
        {
            animator.SetBool("Correr", true);
            animator.SetBool("caminar_Atras", false);
            animator.SetBool("Idle", false);
        }
        else if (Input.GetAxisRaw("Vertical") < 0f)
        {
            animator.SetBool("Correr", false);
            animator.SetBool("caminar_Atras", true);
            animator.SetBool("Idle", false);

            movementSpeed = velocidadRetroceder;
        }*/
        else
        {
            movementSpeed = baseSpeed;
        }

        // Rotación de la cámara 

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        Quaternion targetRotationX = Quaternion.Euler(0f, mouseX, 0f);
        Quaternion targetRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        playerCamera.transform.localRotation = Quaternion.Lerp(playerCamera.transform.localRotation, targetRotation, smoothRotation * Time.deltaTime);
        transform.Rotate(Vector3.up * mouseX);
    }

}

