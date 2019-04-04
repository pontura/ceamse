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
    public SceneObject draggingObject;
   public Tile lastTileSelected;
    Vector2 pos;

    void Start()
    {
        pos = Vector3.zero;
    }

    void Update()
    {

        if (Input.GetMouseButton(0) && draggingObject == null)
        {
            OnDown();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            OnUp();
        }

       

        if (draggingObject)
            DragUpdate();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            pos = hit.transform.position;
            Tile tile = hit.transform.gameObject.GetComponent<Tile>();
            if (tile == null)
                return;

            if (lastTileSelected != null)
            {
                if (lastTileSelected == tile)
                    return;
                else
                    lastTileSelected.OnSelect(false);
            }

            lastTileSelected = tile;
            SetSelect(lastTileSelected, true);
        }
       
    }
    void OnDown()
    {
        if (lastTileSelected == null || lastTileSelected.sceneObject == null)
            return;
        
        draggingObject = lastTileSelected.sceneObject;
        lastTileSelected.OnGrabSceneObject();
    }
    void OnUp()
    {
        if (!draggingObject)
            return;
        Game.Instance.sceneObejctsManager.AddSOToTile(draggingObject, lastTileSelected);
        draggingObject = null;
    }
    void SetSelect(Tile lastTileSelected, bool isSelected)
    {
         lastTileSelected.OnSelect(isSelected);
    }
    void DragUpdate()
    {
        draggingObject.transform.position = Vector3.Lerp(draggingObject.transform.position, pos, 0.1f);
    }
}
