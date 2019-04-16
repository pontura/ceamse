using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public bool working;
    public Transform container;
    int total = 4;
    int separation = 80;
    int id;
    public List<Tile> tiles;
    int idDone;
    private void Start()
    {
        Events.newSOAdded += newSOAdded;
    }
    void newSOAdded()
    {
        if (working)
            return;
        bool skip = false;
        foreach(Tile t in tiles)
        {
            if (t.sceneObject == null)
                skip = true;
        }
        if (!skip)
        {
            working = true;
            OnAddNew();
        }
    }
    void OnAddNew()
    {
        
        idDone++;
        if (idDone > total+1)
        {
            EmptyAll();
        }
        else
        {
            AddItem();
        }
    }
    void AddItem()
    {
        float dest = originalPosition.x + (separation * idDone);
        print("dest: " + dest);
        iTween.MoveTo(this.gameObject, iTween.Hash(
              "x", dest,
              "islocal", true,
              "time", 1,
              "oncomplete", "OnAddNew",
              "EaseType", iTween.EaseType.linear,
              "oncompletetarget", this.gameObject
               ));
    }
    Vector3 originalPosition;
    public void Init(Tile tile, int id)
    {
        this.id = id;
        for(int a= 0; a<total; a++)
        {
            Tile newTile = Instantiate(tile);
            newTile.transform.SetParent(container);
            newTile.transform.localPosition = new Vector2(a * separation, 0);
            newTile.transform.localScale = Vector2.one;
            tiles.Add(newTile);
        }
        originalPosition = transform.localPosition;
    }
    void EmptyAll()
    {
        foreach (Tile t in tiles)
        {
            Game.Instance.sceneObejctsManager.DestroySO(t.sceneObject);
            t.OnGrabSceneObject();
        }

        working = false;
        transform.localPosition = originalPosition;
        idDone = 0;
    }
}
