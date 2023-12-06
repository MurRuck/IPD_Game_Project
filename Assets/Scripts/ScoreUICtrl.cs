using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreUICtrl : MonoBehaviour
{
    public Animation ani;
    public GameObject[] Stars;
    public GameObject SingleTon;

    public TMP_Text ScoreGame;

    public GameObject NewGame;
    // Start is called before the first frame update
    void Start()
    {
        
        SingleTon = GameObject.Find("SingleTon");

        if (SingleTon.GetComponent<GameManager>().GameScore > 5000)
        {
            Invoke("Star", 0.5f);
        }
        if (SingleTon.GetComponent<GameManager>().GameScore > 15000)
        {
            Invoke("Star1", 1.0f);
        }
        if (SingleTon.GetComponent<GameManager>().GameScore > 25000)
        {
            Invoke("Star2", 2.5f);
        }
        
        ScoreGame.text = SingleTon.GetComponent<GameManager>().GameScore.ToString();


        if(SingleTon.GetComponent<GameManager>().GameScore > SingleTon.GetComponent<GameManager>().MaxScore)
        {
            SingleTon.GetComponent<GameManager>().MaxScore = SingleTon.GetComponent<GameManager>().GameScore;

            Invoke("NewGameSet", 0.5f);
        }


    }
    
    void NewGameSet()
    {
        NewGame.SetActive(true);
    }

    public void Coll()
    {
        SceneManager.LoadScene(4);
    }

    void Star()
    {
        Stars[0].SetActive(true);
    }
    void Star1()
    {
        Stars[1].SetActive(true);
    }
    void Star2()
    {
        Stars[2].SetActive(true);
    }

    public void Cancle()
    {
        SceneManager.LoadScene(0);
    }

    public void ConTinue()
    {
        SceneManager.LoadScene(1);
    }

}
