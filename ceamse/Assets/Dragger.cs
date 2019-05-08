using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{

    public SceneObject sceneObject;
    public Tooltip tooltip;

    void Start()
    {
        Events.OnSlotOver += OnSlotOver;
    }
    void OnDestroy()
    {
        Events.OnSlotOver -= OnSlotOver;
    }
    void OnSlotOver(bool isOver, SceneObject.types type)
    {
        if (sceneObject != null)
            tooltip.SetState(isOver, type.ToString());
    }
    public void Init(SceneObject so)
    {
        this.sceneObject = so;
        so.transform.SetParent(transform);
        so.transform.localPosition = Vector3.zero;
        transform.localPosition = Input.mousePosition;
    }
    public void DropSceneObject()
    {
        this.sceneObject = null;
        tooltip.SetState(false, "");
    }
    void Update()
    {
        Vector2 dest = Input.mousePosition;
        dest.x -= Screen.width / 2;
        dest.y -= Screen.height / 2;
        dest /= GetComponentInParent<Canvas>().scaleFactor;
        transform.localPosition = Vector3.Lerp(transform.localPosition, dest, 0.2f);
    }
}
