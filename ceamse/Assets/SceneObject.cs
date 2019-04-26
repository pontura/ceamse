using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneObject : MonoBehaviour
{
    public Tile myTile;

    public GameObject[] items;
    public int id;

    public void Init(Tile _tile, int id)
    {
        int n = 0;
        foreach (GameObject go in items)
        {
            if (id == n)
                go.SetActive(true);
            else
                go.SetActive(false);
            n++;
        }
        this.myTile = _tile;
    }
    public void Init(Tile _tile)
    {
        id = Random.Range(0, items.Length);
        int n = 0;
        foreach(GameObject go in items)
        {
            if (id == n)
                go.SetActive(true);
            else
                go.SetActive(false);
            n++;
        }
        this.myTile = _tile;
    }
    public types type;
    public enum types
    {
        NONE,
        PLASTICO,
        PAPEL,
        METAL,
        TETRA,
        VIDRIO
    }
    public void Move()
    {
        if (myTile == null)
            return;
      
        transform.position = myTile.transform.position;
    }
}
