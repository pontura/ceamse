using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
   
    int total = 4;
    int separation = 80;
    int id; 

    public void Init(Tile tile, int id)
    {
        this.id = id;
        for(int a= 0; a<total; a++)
        {
            Tile newTile = Instantiate(tile);
            newTile.transform.SetParent(transform);
            newTile.transform.localPosition = new Vector2(a * separation, 0);
            newTile.transform.localScale = Vector2.one;
        }
    }
}
