using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMechanic : MonoBehaviour
{
    public GameObject portals; // Reference to your portal prefab

    private void Start()
    {
        StartCoroutine(MoveTilesTimer());
    }

    IEnumerator MoveTilesTimer()
    {
        yield return new WaitForSeconds(10);

        while (true)
        {
            StartCoroutine(TeleportAllTiles(0.5f));
            yield return new WaitForSeconds(10);
        }
    }


    IEnumerator TeleportAllTiles(float duration)
    {
        portals.SetActive(true);

        int tileCount = Path.lanes[0].childCount;

        // List to store all coroutines
        List<Coroutine> tileCoroutines = new List<Coroutine>();

        for (int j = 0; j < tileCount; j++)
        {

            // Collect all the target positions for the tiles
            Vector3[] targetPositions = new Vector3[Path.lanes.Length];

            for (int i = 0; i < Path.lanes.Length; i++)
            {
                Transform currentLane = Path.lanes[i].parent;

                // Calculate the target position by moving all tiles by 3.3 units on the x-axis
                targetPositions[i] = currentLane.GetChild(j + 3).position + new Vector3(-3.3f, 0f, 0f);
            }

            // Start a coroutine for each tile and store the reference to it
            Coroutine tileCoroutine = StartCoroutine(MoveTile("Tile" + j, targetPositions, duration));

            // Add the coroutine reference to the list
            tileCoroutines.Add(tileCoroutine);
        }

        // Wait for all tile coroutines to finish
        yield return StartCoroutine(WaitForTileCoroutines(tileCoroutines));

        portals.SetActive(false);
    }

    IEnumerator MoveTile(string tileName, Vector3[] targetPositions, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            for (int i = 0; i < Path.lanes.Length; i++)
            {
                Transform currentLane = Path.lanes[i].parent;
                Transform currentTile = currentLane.Find(tileName);

                // Interpolate between the current position and the target position over time
                currentTile.position = Vector3.Lerp(currentTile.position, targetPositions[i], elapsedTime / duration);
            }

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        // Ensure that all tiles reach their exact target positions at the end
        for (int i = 0; i < Path.lanes.Length; i++)
        {
            Transform currentLane = Path.lanes[i].parent;
            Transform currentTile = currentLane.Find(tileName);
            currentTile.position = targetPositions[i];
        }


        // Move the last tile to the first lane's tile position + 3.3 units on the x-axis
        Transform lastLane = Path.lanes[Path.lanes.Length - 1].parent;
        Transform lastTile = lastLane.Find(tileName);
        lastTile.position = targetPositions[0] + new Vector3(3.3f, 0f, 0f);


        // Change the parents after moving all tiles
        for (int i = 0; i < Path.lanes.Length; i++)
        {
            Transform currentLane = Path.lanes[i].parent;
            Transform currentTile = currentLane.Find(tileName);

            if (i == Path.lanes.Length - 1)
            {
                // If it's the last lane, move the tile to the first lane
                currentTile.GetComponent<Tile>().laneIndex = 0;
                currentTile.SetParent(Path.lanes[0].parent);

                if(currentTile.childCount > 0)
                {
              //      currentTile.GetChild(0).GetComponent<Tower>().SetLaneIndex(0);
                }
            }
            else
            {
                // Move the tile to the next lane
                currentTile.GetComponent<Tile>().laneIndex = i + 1;
                Transform nextLane = Path.lanes[i + 1].parent;
                currentTile.SetParent(nextLane);

                if (currentTile.childCount > 0)
                {
         //           currentTile.GetChild(0).GetComponent<Tower>().SetLaneIndex(i + 1);
                }
            }
        }
    }




    IEnumerator WaitForTileCoroutines(List<Coroutine> coroutines)
    {
        // Wait for all coroutines to finish
        foreach (var coroutine in coroutines)
        {
            yield return coroutine;
        }
    }


}