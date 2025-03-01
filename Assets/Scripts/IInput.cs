using System;
using UnityEngine;
using UnityEngine.Events;

public interface IInput : ICameraInput, IMoveInput, IDropInput, IItemClick {
    //public event IDropInput.eventHandler onDrop;
    //public event IMoveInput.eventVector2Handler onMove;
    //public event ICameraInput.eventVector2Handler onCameraMove;
}

public interface ICameraInput {
    public delegate void eventVector2Handler(Vector2 col);

    public event eventVector2Handler onCameraMove;

    public virtual void cameraInvoke(Vector2 vec) { }
}
public interface IMoveInput {
    public delegate void eventVector2Handler(Vector2 col);

    public event eventVector2Handler onMove;
}

public interface IDropInput {
    public delegate void eventHandler();

    public event eventHandler onDrop;
}

public interface IItemClick {
    public delegate void eventHandlerGameObject(GameObject gameObject);

    public event eventHandlerGameObject onItemClick;
    public virtual void invokeItemClick(GameObject gObj) { }
}