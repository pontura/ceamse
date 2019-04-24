using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    Animation anim;
    public SceneObject sceneObject;
    public GameObject selection;
    public bool topDown;
    float offset = 525;
    bool canInteract = true;

    void Start()
    {
        anim = GetComponent<Animation>();
    }
    public void SetInteraction(bool isOn)
    {
        canInteract = isOn;
        OnSelect(false);
    }
    public void OnMouseOvers( bool isOver)
    {
        if (!canInteract)
            return;

        Events.OnMouseOver(isOver, gameObject);
    }
    public void OnPonterDown(bool isClick)
    {
        if (!canInteract)
            return;
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
                Events.NewSlotInLane();
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
        // selection.SetActive(isSelected);
        if (!anim)
            return;
        if(isSelected)
            anim.Play("slot_on");
        else
            anim.Play("slot");
    }
    public void OnGrabSceneObject()
    {
        sceneObject.myTile = null;
        sceneObject = null;
    }
}
