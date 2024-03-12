using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{
    [SerializeField] public static Transform[] lanes;

    private void Awake()
    {
        lanes = new Transform[transform.childCount];

        for (int i = 0; i < lanes.Length; i++)
        {
            lanes[i] = transform.GetChild(i).GetChild(0);
        }
    }
}
