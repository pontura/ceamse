using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Summary : MonoBehaviour
{

    public Text field;
    void Start()
    {
        int total = Data.Instance.GetTotalCorrectResults();
        if(total == 0)
            field.text = "No pudiste reciclar ningún objeto. ¡Más suerte la próxima!";
        else
            field.text = "¡Bravo! Reciclaste " + total  +  " objetos.";
    }
    public void Restart()
    {
        Events.ResetGame();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Splash");
    }
}
