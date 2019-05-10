using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour
{
    int total = 5;
    float separation = 72;
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
            newSlots.transform.localPosition = new Vector2(a * separation, -a * separation);
            newSlots.transform.localScale = Vector2.one;
          
            newSlots.transform.SetParent(masks[a]);
            newSlots.Init(tile, a);
        }
    }
}
