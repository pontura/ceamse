using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSignal : MonoBehaviour
{
    public GameObject panel;
    public Text field;
    public int level = 1;

    void Start()
    {
        panel.SetActive(false);
    }

    public void LevelComplete()
    {
        StartCoroutine(ContinueScene());
        level++;
        field.text = "NIVEL " + level;        
        Events.LevelComplete();
        panel.SetActive(true);
        Invoke("Reset", 2);
    }
    float decreaseTo = 0.1f;
    IEnumerator ContinueScene()
    {
        float t = 1;
        while(t> decreaseTo)
        {            
            t -= 0.05f;
            Time.timeScale = t;
            yield return new WaitForEndOfFrame();
        }        
        yield return new WaitForSecondsRealtime(1);
        t = decreaseTo;
        while (t > decreaseTo)
        {            
            t += 0.05f;
            Time.timeScale = t;
            yield return new WaitForEndOfFrame();
        }
        Time.timeScale = 1;
    }
    void Reset()
    {
        panel.SetActive(false);
    }
}
