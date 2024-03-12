using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TowerChooseButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] TowerPlacementController placementController;
    [SerializeField] private int towerIndex;

    public void OnPointerDown(PointerEventData data)
    {
        placementController.SetTowerIndex(towerIndex);
    }
}
