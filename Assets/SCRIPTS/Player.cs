using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 6.0f;
    [SerializeField] float gravity = -9.81f;

    [Header("Player Inputs")]
    [SerializeField] InputActionReference moveAction;

    CharacterController characterController;

    Vector2 moveInput;
    Vector3 velocity;
    bool isGrounded; 

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable(); 
    }

    void Update()
    {
       ReadInput();
       UpdateGroundedState();
       ApplyGravity();
       ApplyMovement();
    }

    void ReadInput()
    { 
        moveInput = moveAction.action.ReadValue<Vector2>().normalized;
    }
    void UpdateGroundedState()
    {
        isGrounded = characterController.isGrounded;

        if (isGrounded && velocity.y < 0)
            velocity.y = -2;
    }

    void ApplyGravity()
    {
        if (isGrounded || velocity.y > 0)
            velocity.y += gravity * Time.deltaTime;
    }

    void ApplyMovement()
    {
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        Vector3 horizontal = move * moveSpeed;
        Vector3 finalmove = horizontal + Vector3.up * velocity.y;
        characterController.Move(finalmove * Time.deltaTime);
    }
}
