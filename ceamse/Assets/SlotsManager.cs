using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    int total = 6;
    float separation_X = 59f;
    float separation_Y = 59f;
    public Tile tile;
    public Slots slots;
    public Transform container;
    public Transform[] masks;

    void Start()
    {
        for (int a = 0; a < total; a++)
        {
            Slots newSlots = Instantiate(slots);
            newSlots.transform.SetParent(container);
            newSlots.transform.localPosition = new Vector2(a * separation_X, -a * separation_Y);
            newSlots.transform.localScale = Vector2.one;
          
            newSlots.transform.SetParent(masks[a]);
            newSlots.Init(tile, a);
        }
    }
}
