using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SceneObject sceneObject;
    public GameObject selection;
    public bool topDown;
    float offset = 460;

    public void OnMouseOvers( bool isOver)
    {
        Events.OnMouseOver(isOver, gameObject);
    }
    public void OnPonterDown(bool isClick)
    {
        Events.OnClick(isClick, gameObject);
    }
    public void Init(bool topDown)
    {
        this.topDown = topDown;
    }
    public void Move(float value)
    {
        Vector3 pos = transform.localPosition;
       
        if (topDown)
        {
            pos.x += value;
            pos.y -= value;
            transform.localPosition = pos;
            if (pos.x >= offset)
            {
                ResetTile();
            }
        }
        else
        {
            pos.x -= value;
            pos.y += value;
            transform.localPosition = pos;
            if (pos.x <= -offset)
            {
                ResetTile();
            }
        }
        
    }
    void ResetTile()
    {
        if (topDown)
            transform.localPosition = Vector3.zero;
        else
            transform.localPosition = Vector3.zero;
        if (sceneObject)
        {
            Game.Instance.sceneObejctsManager.EndLane(sceneObject, topDown);
            sceneObject = null;
        }
    }
    public void AddSceneObject(SceneObject so)
    {
        this.sceneObject = so;
    }
    public void OnSelect(bool isSelected)
    {
        selection.SetActive(isSelected);
    }
    public void OnGrabSceneObject()
    {
        sceneObject.myTile = null;
        sceneObject = null;
    }
}
