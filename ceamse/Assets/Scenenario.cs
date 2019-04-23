using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenenario : MonoBehaviour
{
    public SceneObject[] all;

    void Start()
    {
        Events.OnFabricaActivate += OnFabricaActivate;
        all = GetComponentsInChildren<SceneObject>();        
    }
    void OnFabricaActivate(SceneObject.types fabricaType, SceneObject.types soType)
    {
        string animName = "lose";
        if (fabricaType == soType)
        {
            Events.OnCorrect(soType);
            animName = "win";
        }
        else
        {
            Events.OnIncorrect(soType);
        }

        SceneObject so = GetFabrica(fabricaType);
        so.GetComponent<Animation>().Play(animName);
        so.GetComponent<SceneSfx>().Play(animName);

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
