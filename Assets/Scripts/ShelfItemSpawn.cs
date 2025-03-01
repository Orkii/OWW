using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class ShelfItemSpawn : MonoBehaviour {
    [SerializeField] List<Transform> spawnPoints;

    [Inject] SurvivalItemsList itemsToSpawn;

    void Start() {
        Debug.Log("Item to spawn = " + itemsToSpawn);

        //return;
        foreach (Transform item in spawnPoints) {
            int i = Random.Range(0, itemsToSpawn.items.Count);
            GameObject gObj = Instantiate(itemsToSpawn.items[i]);
            gObj.transform.position = item.position;
        }
    }

    void Update() {
        
    }
}
