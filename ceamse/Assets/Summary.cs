using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{
    public SceneObject[] masks;

    public Text field;
    void Start()
    {
        int total = Data.Instance.GetTotalCorrectResults();
        if(total == 0)
            field.text = "No pudiste reciclar ningún objeto. ¡Más suerte la próxima!";
        else
            field.text = "¡Bravo! Reciclaste " + total  +  " objetos.";

        SetMasks();
    }
    public void Restart()
    {
        Events.ResetGame();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Splash");
    }
    void SetMasks()
    {
        foreach(Data.ResultsItem ri in Data.Instance.results)
        {
            SceneObject so = GetMask(ri.type);
            so.GetComponentInChildren<SummaryNum>().Init(ri.correct_qty);
            if (ri.correct_qty == 0)
                so.gameObject.SetActive(true);
            else
                so.gameObject.SetActive(false);
        }
    }
    SceneObject GetMask(SceneObject.types type)
    {
        foreach(SceneObject so in masks)
        {
            if(so.type == type)
            return so;
        }
        return null;
    }
}
