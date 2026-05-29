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
    [SerializeField] InputActionReference InteractAction;

    [Header("Player Interact")]
    [SerializeField] private float radius = 2f;
    [SerializeField] private LayerMask interactableLayers;
    private Collider[] buffer = new Collider[32];
    private IInteractable focused;

    CharacterController characterController;

    [SerializeField] private InteractionPrompt prompt;

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

        IInteractable nearest = FindNearestInteractable();
        UpdateFocus(nearest);
    }

    void ReadInput()
    { 
        moveInput = moveAction.action.ReadValue<Vector2>().normalized;

        if (focused != null && InteractAction.action.WasPressedThisFrame())
        {
            if (focused.CanInteract())
            {
                focused.Interact();
            }
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
        Vector3 move = transform.right * moveInput.x + transform.forward * moveInput.y;
        Vector3 horizontal = move * moveSpeed;
        Vector3 finalmove = horizontal + Vector3.up * velocity.y;
        characterController.Move(finalmove * Time.deltaTime);
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
