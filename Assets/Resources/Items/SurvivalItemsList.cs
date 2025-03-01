using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "SurvivalItemsList", menuName = "Scriptable Objects/SurvivalItemsList")]
public class SurvivalItemsList : ScriptableObject{
    [SerializeField] public List<GameObject> items;
}

