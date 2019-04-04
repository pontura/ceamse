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
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<Game>();
            }
            return mInstance;
        }
    }
    void Awake()
    {
        if (!mInstance)
            mInstance = this;
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);

        sceneObejctsManager = GetComponent<SceneObjectsManager>();
        lanesManager = GetComponent<LanesManager>();
    }

}
