using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapMask : MonoBehaviour
{
    //-- Made by @CalmlyGrass
    //-- License: Apache 2.0

    public GameObject maskCell;

    private void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        Vector3Int startCoord = tilemap.origin;
        Vector3Int size = tilemap.size;

        //Iterate over each cell
        for (int x = startCoord.x; x < startCoord.x + size.x; x++)
        {
            for (int y = startCoord.y; y < startCoord.y + size.y; y++)
            {
                //Check if cell isn't empty
                if (tilemap.GetTile(new Vector3Int(x, y, startCoord.z)) != null)
                {
                    //Create maskCell on the cell coords
                    Vector3 coord = tilemap.CellToWorld(new Vector3Int(x, y, startCoord.z)) + new Vector3(0.5f, 0.5f, 0);
                    Instantiate(maskCell, coord, Quaternion.identity, transform);
                }
            }
        }
    }
}
