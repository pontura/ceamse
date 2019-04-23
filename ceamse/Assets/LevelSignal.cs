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
        level++;
        field.text = "NIVEL " + level;        
        Events.LevelComplete();
        panel.SetActive(true);
        Invoke("Reset", 2);
    }
    void Reset()
    {
        panel.SetActive(false);
    }
}
