using System;
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
    [SerializeField] InputActionReference lookAction;
    [SerializeField] InputActionReference InteractAction;
    [SerializeField] InputActionReference PauseAction;

    [Header("Look Settings")]
    [SerializeField] Transform playerCamera; 
    [SerializeField] float sensitivity = 0.1f;
    float xRotation = 0f;

    [Header("Player Interact")]
    [SerializeField] private float radius = 2f;
    [SerializeField] private LayerMask interactableLayers;
    private Collider[] buffer = new Collider[32];
    private IInteractable focused;

    [Header("Player Animation & Sound")]
    [SerializeField] private Animator animator;
    [SerializeField] private AudioClip audioAndando;

    CharacterController characterController;
    [SerializeField] AudioSource audio;

    [SerializeField] private InteractionPrompt prompt;

    Vector2 moveInput;
    Vector2 lookInput;
    Vector3 velocity;
    bool isGrounded;

    public static bool isPaused;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
        animator = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        isPaused = false;
    }

    private void OnEnable()
    {
        moveAction.action.Enable();
        lookAction.action.Enable();
        PauseAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        lookAction.action.Disable();
        PauseAction.action.Disable(); 
    }

    void Update()
    {
       ReadInput();
       UpdateGroundedState();
       ApplyGravity();
       ApplyMovement();
       HandleLook();

        bool isMoving = moveInput.sqrMagnitude > 0.01f;

        if (isMoving)
        {
            animator.SetBool("IsMoving", true);
 
            if (!audio.isPlaying)
            {
                audio.clip = audioAndando;
                audio.Play();
            }
        }
        else
        {
            animator.SetBool("IsMoving", false);
            audio.Stop();
        }

        IInteractable nearest = FindNearestInteractable();
        UpdateFocus(nearest);
    }
    void ReadInput()
    {
        moveInput = moveAction.action.ReadValue<Vector2>().normalized;

        lookInput = lookAction.action.ReadValue<Vector2>();

        if (focused != null && InteractAction.action.WasPressedThisFrame())
        {
            if (focused.CanInteract())
            {
                focused.Interact();
            }
        }

        if (!isPaused && PauseAction.action.WasPressedThisFrame())
        { 
            isPaused = true;
        }
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
        if(!isPaused)
        {
            Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
            Vector3 horizontal = move * moveSpeed;
            Vector3 finalmove = horizontal + Vector3.up * velocity.y;
            characterController.Move(finalmove * Time.deltaTime);
        }  
    }

    void HandleLook()
    {
        float mouseX = lookInput.x * sensitivity;
        transform.Rotate(Vector3.up * mouseX);

        if (playerCamera != null)
        {
            float mouseY = lookInput.y * sensitivity;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f); 
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }
    }

    private IInteractable FindNearestInteractable()
    {
        int count = Physics.OverlapSphereNonAlloc(transform.position, radius, buffer, interactableLayers, QueryTriggerInteraction.Collide);
        IInteractable nearest = null;
        float bestDistSq = float.MaxValue;

        for (int i = 0; i < count; i++)
        {
            Collider col = buffer[i];
            if (col == null) continue;
            IInteractable interactable = col.GetComponentInParent<IInteractable>();
            if (interactable == null) continue;
            if (!interactable.CanInteract()) continue;
            float distSq = (col.transform.position - transform.position).sqrMagnitude;
            if (distSq < bestDistSq)
            {
                bestDistSq = distSq;
                nearest = interactable;
            }
        }
        return nearest;
    }

    private void UpdateFocus(IInteractable nearest)
    {
        if (ReferenceEquals(focused, nearest)) return;
        focused?.OnFocusLost();
        focused = nearest;
        if (focused != null)
        {
            focused.OnFocusGained();
            prompt.Show(focused);
        }
        else
        {
            prompt.Hide();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
