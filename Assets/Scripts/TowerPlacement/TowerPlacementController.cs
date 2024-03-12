using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TowerPlacementController : MonoBehaviour
{
    public GameObject[] towerPrefab;

    public LayerMask placementLayer;
    public int towerIndex = 0;
    private GameObject towerPreview;

    private bool isTowerSelected;
    private Tile currentTile;

    private bool canPlaceTower = false;


    private void Update()
    {

        if (isTowerSelected)
        {
#if UNITY_EDITOR
            TowerPreviewPositionEditor();
#else
            TowerPreviewPosition();
#endif
        }
    }

    private void PlaceTower()
    {
        if (canPlaceTower)
        {
            GameObject newTower = Instantiate(towerPrefab[towerIndex], currentTile.transform);
            newTower.transform.localScale = new Vector3(0.3f, 1, 0.3f);
            newTower.transform.position = towerPreview.transform.position;
            newTower.transform.rotation = towerPrefab[towerIndex].transform.rotation;
            
            currentTile.OccupyTile();
            DestroyTowerPreview();
            CameraSystem.instance.isDisabled = false;
            isTowerSelected = false;

            GameManager.Instance.SpendCurrency(newTower.transform.GetChild(0).GetComponent<Tower>().towerCost);
        }
        else
        {
            DestroyTowerPreview();
            CameraSystem.instance.isDisabled = false;
            isTowerSelected = false;
        }

    }

    public void SetTowerIndex(int _index)
    {
        if (towerPreview != null)
        {
            Destroy(towerPreview.gameObject);
        }


        towerIndex = _index;

        if (!(GameManager.Instance.HaveEnoughCurrency(towerPrefab[towerIndex].transform.GetChild(0).GetComponent<Tower>().towerCost)))
        {
            Debug.Log("Not enough currency");
            return;
        }

        CameraSystem.instance.isDisabled = true;

        // Create a new tower preview
        towerPreview = Instantiate(towerPrefab[towerIndex]);
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Convert the mouse position from screen space to world space
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10)); // '10' is the distance from the camera

        // Set the position of the tower preview to the converted world position
        towerPreview.transform.position = new Vector3(worldPosition.x, towerPreview.transform.position.y, worldPosition.z);

        towerPreview.transform.GetChild(0).GetComponent<Collider>().enabled = false;
        towerPreview.transform.GetChild(1).gameObject.SetActive(false);

        // Invoke the towerIsSelected method after a delay
        TowerIsSelected();
        //Invoke("TowerIsSelected", 1);
    }

    private void TowerIsSelected()
    {
        isTowerSelected = true;
    }


#if UNITY_EDITOR

    private void TowerPreviewPositionEditor()
    {
        // Check for mouse input instead of touch
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            UpdateTowerPreviewPosition(Input.mousePosition);
        }

        if (Input.GetMouseButtonUp(0))
        {
            PlaceTower();
        }
    }

#else

    private void TowerPreviewPosition()
    {
        if (towerPreview == null) return;
        if (Input.touchCount < 1) return;

        Touch touch = Input.GetTouch(0);

        switch (touch.phase)
        {
            case TouchPhase.Began:
            case TouchPhase.Moved:
                UpdateTowerPreviewPosition(touch.position);
                break;

            case TouchPhase.Ended:
                PlaceTower();
                break;
        }
    }

#endif

    private void UpdateTowerPreviewPosition(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);

        if (Physics.Raycast(ray, out RaycastHit hitData, 100, placementLayer))
        {
            Vector3 towerPosition = hitData.point;
            currentTile = hitData.collider.gameObject.GetComponent<Tile>();


            // Snap the tower to the center of the tile
            towerPosition = GetCenterOfTile(hitData.collider.gameObject);

            towerPosition.y = towerPrefab[towerIndex].transform.position.y;

            towerPreview.transform.position = towerPosition;
            
            if (currentTile.isOccupied)
            {
                canPlaceTower = false;
                towerPreview.GetComponent<TowerPlacementColor>().SetMaterial(0);
            }
            else
            {
                canPlaceTower = true;
                towerPreview.GetComponent<TowerPlacementColor>().SetMaterial(1);
            }
        }
        else
        {
            canPlaceTower = false;
            towerPreview.GetComponent<TowerPlacementColor>().SetMaterial(0);
        }
    }

    private Vector3 GetCenterOfTile(GameObject tile)
    {
        // Calculate and return the center of the tile
        return tile.transform.position;
    }

    private void DestroyTowerPreview()
    {
        if (towerPreview != null)
        {
            Destroy(towerPreview);
        }
    }
}
