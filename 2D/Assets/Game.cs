﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour {
    public void Replay()
    {
        SceneManager.LoadScene("遊戲");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
