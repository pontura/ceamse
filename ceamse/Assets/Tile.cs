using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public SceneObject sceneObject;
    public GameObject selection;

    public void Move(float value)
    {
        Vector3 pos = transform.localPosition;
        pos.x += value;
        transform.localPosition = pos;
        if(pos.x>=12)
        {
            ResetTile();
        }
    }
    void ResetTile()
    {
        transform.localPosition = Vector3.zero;
        if (sceneObject)
        {
            Game.Instance.sceneObejctsManager.CheckResult(sceneObject);
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
