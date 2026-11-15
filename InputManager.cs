
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using static GameInputAction;

public class InputManager : MonoBehaviour, IPlayerActions
{
    public UnityEvent<Vector2> OnMoveInput;
    public UnityEvent<bool> OnSprintInput;
    private GameInputAction _inputAction;
    

    public void OnInterect(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Interact");
        }
    }

    // Mendeteksi input Move
    public void OnMove(InputAction.CallbackContext context)
    {
        OnMoveInput?.Invoke(context.ReadValue<Vector2>());
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            OnSprintInput?.Invoke(true);
        }
        if(context.canceled)
        {
            OnSprintInput?.Invoke(false);
        }
    }

    private void Awake()
    {
        // Membuat object GameInputAction
        _inputAction = new GameInputAction();

        // Mengaktifkan input action
        _inputAction.Enable();

        // Mengaktifkan action map Player
        _inputAction.Player.Enable();

        // Mendaftarkan callback input dari action map Player
        _inputAction.Player.SetCallbacks(this);
    }
}