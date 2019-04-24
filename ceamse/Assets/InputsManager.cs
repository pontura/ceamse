using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputsManager : MonoBehaviour
{
    public states state;
    public enum states
    {
        IDLE
    }
    public Dragger dragger;
    public Tile tileSelected;
    public SceneObjectsManager sceneObjectsManager;


    private void Start()
    {
        Physics.queriesHitTriggers = true;
        Events.OnMouseOver += OnMouseOver;
        Events.OnClick += OnClick;
    }
    void OnDestroy()
    {
        Events.OnMouseOver -= OnMouseOver;
        Events.OnClick -= OnClick;
    }
    void OnClick(bool isDown, GameObject go)
    {
        if (isDown)
        {
            //clickea sobre un item y lo agarra
            Tile tile = go.GetComponent<Tile>();
            if (tile == null) return;
            SceneObject so = tile.sceneObject;

            if (so == null) return;
            if (dragger.sceneObject != null) return;
            dragger.Init(so);
            sceneObjectsManager.StartDragging(so);
            tile.OnGrabSceneObject();
        } else
        {
            //release sobre un tile y lo deja
            if (tileSelected == null) return;
            SceneObject so = dragger.sceneObject;
            if (so == null) return;
            dragger.DropSceneObject();
            SceneObject soInNewTile = tileSelected.sceneObject;
           
            if(soInNewTile != null)
            {
                dragger.Init(soInNewTile);
                sceneObjectsManager.StartDragging(soInNewTile);
                tileSelected.OnGrabSceneObject();
            }
            sceneObjectsManager.AddSOToTile(so, tileSelected, true);
        }
    }
    void OnMouseOver(bool isOver, GameObject go)
    {
        tileSelected = go.GetComponent<Tile>();
        if(tileSelected != null)
        {
            tileSelected.OnSelect(isOver);
        }
    }
    void Update()
    {

    }
   
}
