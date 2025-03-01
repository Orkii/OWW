using UnityEngine;
using Zenject;

public class ItemTaker : MonoBehaviour {
    [Inject] IInput input;
    [SerializeField] GameObject arm;
    [SerializeField] GameObject perent;


    [SerializeField] float throwForce = 5;

    //bool carrySMTH = false;
    GameObject itemInArm;
    Rigidbody itemRB;
    void Start() {
        perent = arm.transform.parent.gameObject;
        input.onItemClick += InputOnItemClick;
        input.onDrop += InputOnDrop;
    }

    private void InputOnDrop() {
        if (itemInArm == null) return;
        itemInArm.GetComponent<Collider>().isTrigger = false;
        itemRB.useGravity = true;


        itemRB.AddForce(Camera.main.transform.forward * throwForce, ForceMode.Impulse);
        itemInArm.transform.parent = null;
        itemRB = null;
        itemInArm = null;
        arm.SetActive(true);

    }

    private void InputOnItemClick(GameObject item) {
        //Debug.Log("ItemTaker item clicked");
        if (itemInArm != null) return;

        item.transform.parent = perent.transform;
        item.transform.position = arm.transform.position;
        item.transform.rotation = arm.transform.rotation;
        itemInArm = item;
        itemInArm.GetComponent<Collider>().isTrigger = true;
        itemRB = itemInArm.GetComponent<Rigidbody>();
        itemRB.useGravity = false;
        arm.SetActive(false);

    }

    void Update() {
        
    }
}
