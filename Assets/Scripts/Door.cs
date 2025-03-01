
using UnityEngine;

public class Door : MonoBehaviour {

    [SerializeField] Animator animator;
    [SerializeField] RuntimeAnimatorController animatorController;

    void Start() {
        animator = GetComponent<Animator>();
        animator.SetBool("open", true);
    }

    
    void Update() {
        
    }
}
