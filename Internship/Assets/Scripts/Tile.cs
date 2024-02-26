using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private float disableTime = 2.5f;

    private void OnTriggerExit(Collider other)
    {
        GameMenu.instance.AddCount();
        StartCoroutine(DisableTile());
    }

    IEnumerator DisableTile()
    {
        yield return new WaitForSeconds(disableTime);
        TileGenerator.instance.tiles.Add(gameObject);
        TileGenerator.instance.SpawnTile();
        gameObject.SetActive(false);
    }
}
