using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject : MonoBehaviour
{
    public Tile myTile;

    public void Init(Tile _tile)
    {
        this.myTile = _tile;
    }
    public types type;
    public enum types
    {
        VIDRIO,
        PAPEL,
        CHAPA,
        TETRA,
        ALUMINIO,
        LATA
    }
    public void Move()
    {
        if (myTile == null)
            return;
      
        transform.position = myTile.transform.position;
    }
}
