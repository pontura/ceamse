using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summary : MonoBehaviour
{
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
