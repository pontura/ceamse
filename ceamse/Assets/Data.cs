using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Data : MonoBehaviour
{
    public float lifes;

    const string PREFAB_PATH = "Data";
    static Data mInstance = null;

    public ResultsItem[] results;
    [Serializable]
    public class ResultsItem
    {
        public SceneObject.types type;
        public int correct_qty;
    }

    public static Data Instance
    {
        get
        {
            if (mInstance == null)
            {
                mInstance = FindObjectOfType<Data>();

                if (mInstance == null)
                {
                    GameObject go = Instantiate(Resources.Load<GameObject>(PREFAB_PATH)) as GameObject;
                    mInstance = go.GetComponent<Data>();
                }
            }
            return mInstance;
        }
    }
    public void LoadLevel(string aLevelName)
    {
        Debug.Log("Load Scene " + aLevelName);
        SceneManager.LoadScene(aLevelName);
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
    }
    void Start()
    {
        Events.OnFabricaActivate += OnFabricaActivate;
        Events.ResetGame += ResetGame;
    }
    void OnDestroy()
    {
        Events.OnFabricaActivate -= OnFabricaActivate;
        Events.ResetGame -= ResetGame;
    }
    void OnFabricaActivate(SceneObject.types fabricaType, SceneObject.types soType)
    {
        if (fabricaType == soType)
            GetResult(soType).correct_qty++;
    }
    ResultsItem GetResult(SceneObject.types soType)
    {
        foreach (ResultsItem r in results)
        {
            if (r.type == soType)
                return r;
        }
        return null;
    }
    public int GetTotalCorrectResults()
    {
        int total = 0;

        foreach (ResultsItem r in results)
            total += r.correct_qty;

        return total;
    }
    void ResetGame()
    {
        foreach (ResultsItem r in results)
            r.correct_qty = 0;
    }
}
