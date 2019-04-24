using UnityEngine;
using System.Collections;
using System;

public class Game : MonoBehaviour
{
    public states state;
    public enum states
    {
        PLAYING,
        GAME_OVER
    }
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

        Events.GameOver += GameOver;
    }
    void Destroy()
    {
        Events.GameOver -= GameOver;
    }
    void GameOver()
    {
        state = states.GAME_OVER;
        Invoke("GameOverDelayed", 2);
    }
    void GameOverDelayed()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Sumary");
    }

}
