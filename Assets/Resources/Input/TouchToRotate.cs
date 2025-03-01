using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;
using static IInput;

public class TouchToRotate : MonoBehaviour {
    
    [Inject] ICameraInput cameraInput;
    [Inject] IItemClick itemClick;

    [SerializeField] List<Transform> clickArea;

    float itemTakeDistance = 5;

    //Vector2 prevPos;
    //Vector2 deltaMove;
    bool prevTouched = false;

    //IInput mInput;


    private void Start() {
        if (cameraInput != null) {
            Debug.Log("TouchToRotate = " + cameraInput.GetType());
        }
        else {
            Debug.Log("TouchToRotate = NULL");
        }
    }

    void Update() {
        checkTouchMove();
        checkTouchItem();
        Input.GetKey(KeyCode.Space);
    }

    void checkTouchItem() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, itemTakeDistance)) {
                if (raycastHit.transform != null) {
                    if (raycastHit.transform.gameObject.tag == "Item") {

                        if (itemClick != null) itemClick.invokeItemClick(raycastHit.transform.gameObject);
                    }
                }
            }
        }
    }

    void checkTouchMove() {

        if (Input.touchCount == 0) {
            prevTouched = false;
            return;
        }

        if (prevTouched == false) {
            //prevPos = Input.touches[0].deltaPosition;
            prevTouched = true;
            return;
        }
        for (int i = 0; i < Input.touchCount; i++) {
            PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
            eventDataCurrentPosition.position = new Vector2(Input.GetTouch(i).position.x, Input.GetTouch(i).position.y);
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

            if (results.Count == 0) {
                continue;
            }
            if (results.Count > 0) {

                foreach (Transform t in clickArea) {
                    if (results[0].gameObject.transform == t) {
                        cameraInput.cameraInvoke(Input.touches[i].deltaPosition);
                        break;
                    }
                }                
            }
        }
    }
}
