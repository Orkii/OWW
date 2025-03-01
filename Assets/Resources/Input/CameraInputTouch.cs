using System;
using UnityEngine;
using UnityEngine.Events;

public class CameraInputTouch : ICameraInput {
    public event ICameraInput.eventVector2Handler onCameraMove;

    public void cameraInvoke(Vector2 vec) {
        if (onCameraMove != null) onCameraMove.Invoke(vec);
    }
}