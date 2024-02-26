using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public class TileGenerator : MonoBehaviour
{
    public static TileGenerator instance;

    [SerializeField] private int roadLength;

    public List<GameObject> tiles;

    private Vector3 nextSpawnPoint;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SpawnTile(false);

        for (int i = 0; i < roadLength - 1; i++)
        {
            SpawnTile();
        }
    }

    public void SpawnTile(bool withObstacle = true)
    {
        System.Random rnd = new System.Random();
        int tileIndex = rnd.Next(0, tiles.Count);

        if (!withObstacle)
        {
            tileIndex = 0;
        }

        GameObject tile = tiles[tileIndex];
        tiles.Remove(tile);
        tile.transform.position = nextSpawnPoint;
        tile.gameObject.SetActive(true);
        nextSpawnPoint = tile.transform.GetChild(1).transform.position;
    }
}
