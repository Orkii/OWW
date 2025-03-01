using UnityEngine;
using Zenject;

public class UI : MonoBehaviour {

    [Inject] IInput input;
    [SerializeField] GameObject dropButton;
    void Start() {
        input.onDrop += InputOnDrop;
        input.onItemClick += InputOnItemClick;
    }

    private void InputOnItemClick(GameObject gameObject) {
        dropButton.SetActive(true);
    }

    private void InputOnDrop() {
        dropButton.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }
}
