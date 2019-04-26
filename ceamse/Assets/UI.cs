using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text levelField;
    public Text levelFieldNums;
    public Image levelBar;
    public int itemsByLevel;
    int totalItemsByLevel;

    public Image bar;
    public float life = 1;
    LevelSignal levelSignal;
    public GameObject gameOverSignal;

    void Start()
    {
        gameOverSignal.SetActive(false);
        levelSignal = GetComponent<LevelSignal>();
        life = 1;
        itemsByLevel = 0;
        totalItemsByLevel = 3;
        SetLevelValue();
        Events.OnIncorrect += OnIncorrect;
        Events.OnCorrect += OnCorrect;
        Events.GameOver += GameOver;
    }
    void OnDestroy()
    {
        Events.GameOver -= GameOver;
        Events.OnIncorrect -= OnIncorrect;
        Events.OnCorrect -= OnCorrect;
    }
    void GameOver()
    {
        gameOverSignal.SetActive(true);
    }
    void OnCorrect(SceneObject.types type)
    {
        itemsByLevel++;
        SetLevelValue();
    }
    void OnIncorrect(SceneObject.types type)
    {
        if (Game.Instance.state == Game.states.GAME_OVER)
            return;

        Resta( 1/Data.Instance.lifes );      
    }
    void Resta(float value)
    {
        life -= value;
        if(life <= 0)
        {
            Events.GameOver();
            life = 0;
        }
        bar.fillAmount = life;
    }
    void SetLevelValue()
    {
        if(itemsByLevel >= totalItemsByLevel)
        {
            levelSignal.LevelComplete();
            itemsByLevel = 0;
            totalItemsByLevel += 3;
        }
        levelField.text = "Nivel " + levelSignal.level;
        levelFieldNums.text =  itemsByLevel + "/" + totalItemsByLevel ;

        levelBar.fillAmount = (float)itemsByLevel / (float)totalItemsByLevel;
    }
}
