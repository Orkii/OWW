using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

public class PlayerInput : IInput {
    public InputSystem1 inputSystem;
    [Inject] public ICameraInput cameraInput;
    [Inject] public IItemClick itemClickInput;
    public event IDropInput.eventHandler onDrop;
    public event IMoveInput.eventVector2Handler onMove;

    public event ICameraInput.eventVector2Handler onCameraMove;
    public event IItemClick.eventHandlerGameObject onItemClick;



    //public event ICameraInput.eventVector2Handler onCameraMove;

    //public touchCameraMove;



    public PlayerInput(ICameraInput cameraInput_, IItemClick itemClick_) {
        cameraInput = cameraInput_;
        itemClickInput = itemClick_;
        //Debug.Log("PlayerInput alaive");
        inputSystem = new InputSystem1();
        inputSystem.PlayerInput.Drop.performed += Drop_performed;
        inputSystem.PlayerInput.Move.performed += Move_performed; // Move
        inputSystem.PlayerInput.Move.canceled += Move_performed;  // Stope move

        cameraInput.onCameraMove += CameraInput_onCameraMove;
        itemClickInput.onItemClick += ItemClickInputOnItemClick;

        inputSystem.Enable();
    }

    private void ItemClickInputOnItemClick(GameObject gameObject) {
        Debug.Log("Item was clicked =" + gameObject.name);
        if (gameObject == null) return;
        if (onItemClick != null) onItemClick.Invoke(gameObject);
    }

    private void CameraInput_onCameraMove(Vector2 vec) {
        onCameraMove.Invoke(vec);
        
    }

    private void Move_performed(InputAction.CallbackContext obj) {
        //Debug.Log(1);
        onMove.Invoke(inputSystem.PlayerInput.Move.ReadValue<Vector2>());
    }

    private void Drop_performed(InputAction.CallbackContext obj) {
        //Debug.Log(2); 
        onDrop.Invoke();
    }

}
