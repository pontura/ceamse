using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Tile tile_to_instantiate;
    public List<Tile> tiles;
    public Transform tilesContainer;
    public float separation;
    public int totalTiles = 10;
    public bool top_down;

    public void Init()
    {
        for(int a = 0; a< totalTiles; a++)
        {
            Tile t = Instantiate(tile_to_instantiate);
            t.transform.SetParent(tilesContainer);
            t.transform.localScale = Vector3.one;
            if(top_down)
                t.transform.localPosition = new Vector3(a*separation, -a * separation, 0);
            else
                t.transform.localPosition = new Vector3(-a * separation, a * separation, 0);
            t.Init(top_down);
            tiles.Add(t);
        }
    }
    public void Move(float value)
    {
       foreach(Tile t in tiles)
        {
            t.Move(value);
        }
    }
    public Tile AddSceneObject(SceneObject so, bool top_down)
    {
        Tile tile =  GetFirstTile(top_down);
        tile.AddSceneObject(so);
        return tile;
    }
  
    Tile GetFirstTile(bool top_down)
    {
        if (!top_down)
        {
            float lastX = -1000;
            Tile tile = null;
            foreach (Tile t in tiles)
            {
                if (t.transform.localPosition.x > lastX)
                {
                    tile = t;
                    lastX = t.transform.localPosition.x;
                }
            }
            return tile;
        }
        else
        {
            float lastX = 1000;
            Tile tile = null;
            foreach (Tile t in tiles)
            {
                if (t.transform.localPosition.x < lastX)
                {
                    tile = t;
                    lastX = t.transform.localPosition.x;
                }
            }
            return tile;

        }
    }
}
