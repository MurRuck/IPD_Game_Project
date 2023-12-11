using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public GameObject TimerGame;
    public TMP_Text TimerText;

    public GameObject[] objects;

    public GameObject Scoll;

    public GameObject[] ToggleButtonGame;
    public GameObject PauseGame;
    public GameObject InGame;

    [HideInInspector]
    public bool check = true;
    public float time = 35;

    public GameObject Trash;

    public GameObject TimeOverGame;
    // Start is called before the first frame update
    void Start()
    {

        System.GC.Collect();
    }


    // Update is called once per frame
    void Update()
    {
        if (check)
        {
            time -= Time.deltaTime;
        }

        if (time > 30)
        {
            for (int i = 0; i < objects[1].transform.childCount; i++)
                objects[1].transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;

            for (int i = 0; i < Trash.transform.childCount; i++)
                for(int j = 0; j < Trash.transform.GetChild(i).childCount; j++)
                    Trash.transform.GetChild(i).GetChild(j).GetComponent<SpriteRenderer>().enabled = false;
            //TrickSprite.SetActive(true);
        }
        else
        {
            Scoll.GetComponent<Scrollbar>().size = time * 0.033f;
            for (int i = 0; i < objects[1].transform.childCount; i++)
                objects[1].transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = true;

            for (int i = 0; i < Trash.transform.childCount; i++)
                for (int j = 0; j < Trash.transform.GetChild(i).childCount; j++)
                    Trash.transform.GetChild(i).GetChild(j).GetComponent<SpriteRenderer>().enabled = true;
        }
        if (time <= 32.8f)
        {
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(true);
            }



            if (time <= 0)
            {
                for (int i = 0; i < objects[1].transform.childCount; i++)
                    objects[1].transform.GetChild(i).GetComponent<SpriteRenderer>().enabled = false;
                TimeOverGame.SetActive(true);
                Invoke("ChangeScene", 1f);
            }
        }


        if(time <= 0)
        {

        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(3);
    }


    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void ToggleButton(int a)
    {
        ToggleButtonGame[a].GetComponent<Animator>().SetBool("Reverse", !ToggleButtonGame[a].GetComponent<Animator>().GetBool("Reverse"));
        
    }
    public void Setting()
    {
        check = !check;
        PauseGame.SetActive(!PauseGame.activeInHierarchy);
         for(int i = 0; i < 64; i++)
            InGame.transform.GetChild(i).gameObject.SetActive(!InGame.transform.GetChild(i).gameObject.activeInHierarchy);
         

    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
}
