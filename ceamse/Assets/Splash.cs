﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    public void GotoGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
