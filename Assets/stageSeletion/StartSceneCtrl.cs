﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneCtrl : MonoBehaviour
{
    public GameObject SettingGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void CollectionScene()
    {
        SceneManager.LoadScene(4);
    }
}
