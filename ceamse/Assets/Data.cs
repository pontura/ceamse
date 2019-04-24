﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class Data : MonoBehaviour
{
    public float lifes;

    const string PREFAB_PATH = "Data";    
    static Data mInstance = null;

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
		Debug.Log ("Load Scene " + aLevelName);
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

}
