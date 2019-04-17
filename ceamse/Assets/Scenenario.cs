using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenenario : MonoBehaviour
{
    public SceneObject[] all;

    void Start()
    {
        all = GetComponentsInChildren<SceneObject>();
        Events.OnFabricaActivate += OnFabricaActivate;
    }
    void OnFabricaActivate(SceneObject.types fabricaType, SceneObject.types soType)
    {
       
        string animName = "lose";
        if (fabricaType == soType)
            animName = "win";
        GetFabrica(fabricaType).GetComponent<Animation>().Play(animName);

        print("pone en " + fabricaType + "  soType: " + soType + " _ " + animName);
    }
    SceneObject GetFabrica(SceneObject.types type)
    {
        foreach (SceneObject f in all)
            if (f.type == type)
                return f;
        return null;
    }
}
