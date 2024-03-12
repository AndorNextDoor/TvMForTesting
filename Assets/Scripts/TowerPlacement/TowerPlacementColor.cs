using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacementColor : MonoBehaviour
{
    [SerializeField] private GameObject[] materialsToChange;
    [SerializeField] private Material[] Materials;

    
    // 0 = invalid material | 1 = valid material
    public void SetMaterial(int materialID)
    {
        foreach (var mat in materialsToChange)
        {
            mat.GetComponent<Renderer>().material = Materials[materialID];
        }
    }
}
