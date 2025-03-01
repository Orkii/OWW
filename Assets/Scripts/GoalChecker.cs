using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GoalChecker : MonoBehaviour
{
    const int itemGoal = 20;
    float speed = 1f;
    [SerializeField] bool isFinish = false;
    [SerializeField] GameObject car;

    [SerializeField] List<GameObject> items = new List<GameObject>();


    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if (isFinish) {
            Vector3 delta = car.transform.forward * Time.deltaTime * speed;
            car.transform.position += delta;

            foreach (GameObject item in items) {
                item.transform.position += delta;
            }


            speed += Time.deltaTime/2;
        }
    }

    private void finish() {

        foreach (GameObject item in items) {
            item.transform.parent = car.transform;
        }

        isFinish = true;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("OnTriggerEnter");
        if (other.tag == "Item") {
            items.Add(other.gameObject);
        }
        if (items.Count == itemGoal) {
            finish();
        }
    }
    private void OnTriggerExit(Collider other) {
        Debug.Log("OnTriggerEnter");
        if (other.tag == "Item") {
            items.Remove(other.gameObject);
        }
    }

}
