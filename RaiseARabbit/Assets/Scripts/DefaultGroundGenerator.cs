using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DefaultGroundGenerator : MonoBehaviour
{


    public GameObject tilePref;

    public int numTiles = 10;
    public int tileSize = 10;
        // Use this for initialization
    void Start()
    {

        for (int i = -numTiles / 2; i < numTiles / 2; i++)
        {
            for (int j = -numTiles / 2; j < numTiles / 2; j++)
            {
                Vector3 tilePos = new Vector3(i* tileSize, 0, j* tileSize);
                GameObject tile = Instantiate(tilePref, tilePos,Quaternion.identity,this.transform);
                tile.transform.localScale = new Vector3(tileSize, 1, tileSize);
                tile.name = "Tile_" + i + "_" + j;
            }
        }
    }

    //// Update is called once per frame
    //void Update () {

    //}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        for (int i = -numTiles / 2; i < numTiles / 2; i++)
        {
            for (int j = -numTiles / 2; j < numTiles / 2; j++)
            {
                Vector3 tilePos = new Vector3(i * tileSize, 0, j * tileSize);

                
                Gizmos.DrawWireCube(tilePos, new Vector3(tileSize , 1, tileSize));
            }
        }
    }
}
