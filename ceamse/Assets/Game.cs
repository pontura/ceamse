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
    void OnDestroy()
    {
        Events.GameOver -= GameOver;
    }
    void GameOver()
    {
        state = states.GAME_OVER;
        StopAllCoroutines();
        StartCoroutine(GameOverCoroutine());
    }
    IEnumerator GameOverCoroutine()
    {
        float t = 1;
        while (t > 0)
        {
            t -= 0.025f;
            if (t < 0)
                t = 0;
            Time.timeScale = t;
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSecondsRealtime(3.5f);
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Sumary");
    }

}
