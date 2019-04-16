using UnityEngine;
using System.Collections;
using System;

public class Game : MonoBehaviour
{
    static Game mInstance = null;
    public LanesManager lanesManager;
    public SceneObjectsManager sceneObejctsManager;

    public static Game Instance
    {
        get
        {
            return mInstance;
        }
    }
    void Awake()
    {
        if (!mInstance)
            mInstance = this;

        sceneObejctsManager = GetComponent<SceneObjectsManager>();
        lanesManager = GetComponent<LanesManager>();
    }

}
