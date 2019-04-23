using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public SceneObject.types type;
    public bool working;
    public Transform container;
    int total = 3;
    int separation = 100;
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
        if (idDone > total)
        {
            EmptyAll();
        }
        else
        {
            SceneObject sceneObject = tiles[2-(idDone-1)].sceneObject;
            Events.OnFabricaActivate(type, sceneObject.type);
            AddItem();
        }
    }
    void AddItem()
    {
        float dest = originalPosition.x + (separation * idDone) * transform.localScale.x;
       
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
        this.type = Game.Instance.sceneObejctsManager.GetTypeByID(id);
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
