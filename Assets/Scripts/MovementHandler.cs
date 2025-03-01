using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public class MovementHandler : MonoBehaviour {
    
    [Inject] MovementCharacteristic mCharact;
    [Inject] IInput input;
    //[Inject(Id = "aaa")] string str;


    const float MAX_CAM_ROT = 90;
    const float MIN_CAM_ROT = -90;

    [SerializeField] Rigidbody rb;
    [SerializeField] CharacterController characterControl;
    [SerializeField] Camera playerCamera;

    bool isMove = false;
    Vector2 moveDir;

    void Start() {
        //Debug.Log("str1 = " + str);
        //Debug.Log(GetType() + " get " + mCharact.GetType() + " as MovementCharacteristic");
        //Debug.Log(GetType() + " get " + input.GetType() + " as input");
        
        input.onDrop += InputOnDrop;
        input.onMove += InputOnMove;
        input.onCameraMove += InputOnCameraMove;

        if (rb == null) rb = GetComponent<Rigidbody>();
        if (characterControl == null) characterControl = GetComponent<CharacterController>();
    }

    private void InputOnCameraMove(Vector2 vec) {
        if (vec.y != 0) { //  /\ \/
            //Debug.Log("Camera1 rot = " + playerCamera.transform.rotation.eulerAngles.x);

            float newXRot = playerCamera.transform.rotation.eulerAngles.x;

            if (newXRot >= 180) newXRot -= 360;
            newXRot += vec.y / 10;

            if (newXRot > MAX_CAM_ROT) newXRot = MAX_CAM_ROT;
            if (newXRot < MIN_CAM_ROT) newXRot = MIN_CAM_ROT;

            playerCamera.transform.rotation = Quaternion.Euler(newXRot,
                                                               playerCamera.transform.rotation.eulerAngles.y,
                                                               playerCamera.transform.rotation.eulerAngles.z);
        }
        if (vec.x != 0) { // <-->  
            float newYRot = transform.rotation.eulerAngles.y - vec.x / 10;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x,
                                                  newYRot,
                                                  transform.rotation.eulerAngles.z);
        }
    }

    private void InputOnMove(Vector2 vec) {
        if (vec == Vector2.zero) {
            isMove = false;
            return;
        }
        isMove = true;
        moveDir = vec;
    }
    void FixedUpdate() {
        if (isMove) {
            Vector3 aaa = transform.TransformDirection(Vector3.forward * moveDir.y + Vector3.right * moveDir.x);

            characterControl.Move(aaa * mCharact.speed);

            //characterControl.Move(new Vector3(moveDir.x, 0 , moveDir.y) * mCharact.speed);
        }
        else {
            //Debug.Log("Stop Move ");
            characterControl.Move(Vector3.zero);
        }
    }

    private void InputOnDrop() {
        //Debug.Log("Drop");
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log(((PlayerInput)input).inputSystem.PlayerInput.Move.ReadValue<Vector2>());
    }
}
