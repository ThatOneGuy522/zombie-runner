using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool shoot;
		public bool zoom;
		public bool key1;
		public bool key2;
		public bool key3;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
#endif


		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void OnShoot(InputValue value)
        {
			ShootInput(value.isPressed);
        }

		public void ShootInput(bool newShootState)
        {
			shoot = newShootState;
        }

		public void OnZoom(InputValue value)
        {
			ZoomInput(value.isPressed);
        }

		public void ZoomInput(bool newZoomState)
        {
			zoom = newZoomState;
        }

		public void OnKey1(InputValue value)
		{
			Key1Input(value.isPressed);
		}

		public void Key1Input(bool newKey1State)
		{
			key1 = newKey1State;
		}
		public void OnKey2(InputValue value)
		{
			Key2Input(value.isPressed);
		}

		public void Key2Input(bool newKey2State)
		{
			key2 = newKey2State;
		}
		public void OnKey3(InputValue value)
		{
			Key3Input(value.isPressed);
		}

		public void Key3Input(bool newKey3State)
		{
			key3 = newKey3State;
		}

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}