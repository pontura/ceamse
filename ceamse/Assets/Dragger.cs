using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    public SceneObject sceneObject;

    public void Init(SceneObject so)
    {
        this.sceneObject = so;
        so.transform.SetParent(transform);
        so.transform.localPosition = Vector3.zero;
    }
    public void DropSceneObject()
    {
        this.sceneObject = null;
    }
    void Update()
    {
        Vector2 dest = Input.mousePosition;
        dest.x -= Screen.width / 2;
        dest.y -= Screen.height / 2;
        transform.localPosition = Vector3.Lerp(transform.localPosition, dest, 0.2f);
    }
}
