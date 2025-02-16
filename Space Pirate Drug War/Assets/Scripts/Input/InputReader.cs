using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IPlayerActions, GameInput.IUIActions
{
    // ---- PLAYER ----
    public event UnityAction<Vector2> moveEvent;

    private GameInput gameInput;

	private void OnEnable()
	{
		if (gameInput == null)
		{
			gameInput = new GameInput();
			gameInput.Player.SetCallbacks(this);
			gameInput.UI.SetCallbacks(this);
		}

		EnablePlayerInput();
	}

	private void OnDisable()
	{
		DisableAllInput();
	}

    // ---- PLAYER ----

    public void OnAttack(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
		if (moveEvent != null)
		{
			moveEvent?.Invoke(context.ReadValue<Vector2>());
		}
    }

    public void OnNext(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPrevious(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    // ---- UI ----

    public void OnNavigate(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubmit(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnRightClick(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnMiddleClick(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnScrollWheel(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnTrackedDevicePosition(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnTrackedDeviceOrientation(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    // ---- ENABLE/DISABLE ----
    
	public void EnablePlayerInput()
	{
		gameInput.Player.Enable();
		gameInput.UI.Disable();
	}

	public void EnableUIInput()
	{
		gameInput.Player.Disable();
		gameInput.UI.Enable();
	}

	public void DisableAllInput()
	{
		gameInput.Player.Disable();
		gameInput.UI.Disable();
	}
}