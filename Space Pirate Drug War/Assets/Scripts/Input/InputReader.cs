using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "InputReader", menuName = "Game/Input Reader")]
public class InputReader : ScriptableObject, GameInput.IStarSystemActions, GameInput.IUIActions
{
    // ---- STAR SYSTEM ----
    public event UnityAction<Vector2> moveEvent;
    public event UnityAction interactEvent;

    private GameInput gameInput;

	private void OnEnable()
	{
		if (gameInput == null)
		{
			gameInput = new GameInput();
			gameInput.StarSystem.SetCallbacks(this);
			gameInput.UI.SetCallbacks(this);
		}

		EnableStarSystemInput();
	}

	private void OnDisable()
	{
		DisableAllInput();
	}

    // ---- STAR SYSTEM ----

    public void OnInteract(InputAction.CallbackContext context)
    {
		if (context.phase == InputActionPhase.Started) {
			interactEvent?.Invoke();
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // no op
    }

    public void OnMove(InputAction.CallbackContext context)
    {
		if (moveEvent != null)
		{
			moveEvent?.Invoke(context.ReadValue<Vector2>());
		}
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
    
	public void EnableStarSystemInput()
	{
		gameInput.StarSystem.Enable();
		gameInput.UI.Disable();
	}

	public void EnableUIInput()
	{
		gameInput.StarSystem.Disable();
		gameInput.UI.Enable();
	}

	public void DisableAllInput()
	{
		gameInput.StarSystem.Disable();
		gameInput.UI.Disable();
	}
}