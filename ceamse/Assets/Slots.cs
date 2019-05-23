using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slots : MonoBehaviour
{
    public SceneObject.types type;
    SceneObject.types SOType;

    public bool working;
    public Transform container;
    int total = 2;
    int separation = 150;
    public List<Tile> tiles;
    int idDone;
    private void Start()
    {
        Events.newSOAdded += newSOAdded;
    }
    void OnDestroy()
    {
        Events.newSOAdded -= newSOAdded;
    }
    void newSOAdded(bool fromDrag)
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

            foreach (Tile t in tiles)
                t.SetInteraction(false);

            working = true;
            OnAddNew();
        }
    }
   
    void OnAddNew()
    {        
        idDone++;
        if(idDone>1)
            Events.OnFabricaActivate(type, SOType);
        if (idDone > total)
        {
            EmptyAll();
        }
        else
        {
            SceneObject sceneObject = tiles[1-(idDone-1)].sceneObject;
            SOType = sceneObject.type;
            AddItem();
        }
    }
    void AddItem()
    {
        float dest = originalPosition.x + (separation * idDone) * transform.localScale.x+50;
       
        iTween.MoveTo(this.gameObject, iTween.Hash(
              "x", dest,
              "islocal", true,
              "time", 0.5f,
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
            newTile.isSlot = true;
            newTile.type = type;
        }
        originalPosition = transform.localPosition;
    }
    void EmptyAll()
    {
        foreach (Tile t in tiles)
        {
            Game.Instance.sceneObejctsManager.DestroySO(t.sceneObject);
            t.OnGrabSceneObject();
            t.SetInteraction(true);
            t.Restart();
        }

        working = false;
        transform.localPosition = originalPosition;
        idDone = 0;
    }
}
