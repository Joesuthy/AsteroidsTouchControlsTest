
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;

    private PlayerInput playerInput;
    private InputAction inputAction;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();


        inputAction = playerInput.actions["Move"];


    }

    private void Update()
    {
        Movement = inputAction.ReadValue<Vector2>();
    }
}
