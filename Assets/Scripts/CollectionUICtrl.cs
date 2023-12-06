using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectionUICtrl : MonoBehaviour
{
    public Sprite[] UnLockSprite;
    public GameObject[] CollectionGame;
    public GameObject ScoreGame;
    // Start is called before the first frame update
    void Start()
    {
        ScoreGame = GameObject.Find("SingleTon");

        if (ScoreGame.GetComponent<GameManager>().MaxScore > 5000)
            CollectionGame[0].GetComponent<Image>().sprite = UnLockSprite[0];

        if (ScoreGame.GetComponent<GameManager>().MaxScore > 10000)
            CollectionGame[1].GetComponent<Image>().sprite = UnLockSprite[1];

        if (ScoreGame.GetComponent<GameManager>().MaxScore > 15000)
            CollectionGame[2].GetComponent<Image>().sprite = UnLockSprite[2];

        if (ScoreGame.GetComponent<GameManager>().MaxScore > 20000)
            CollectionGame[3].GetComponent<Image>().sprite = UnLockSprite[3];

        if (ScoreGame.GetComponent<GameManager>().MaxScore > 25000)
            CollectionGame[4].GetComponent<Image>().sprite = UnLockSprite[4];

        if (ScoreGame.GetComponent<GameManager>().MaxScore > 30000)
            CollectionGame[5].GetComponent<Image>().sprite = UnLockSprite[5];

        if (ScoreGame.GetComponent<GameManager>().MaxScore > 35000)
            CollectionGame[6].GetComponent<Image>().sprite = UnLockSprite[6];

        if (ScoreGame.GetComponent<GameManager>().MaxScore > 40000)
            CollectionGame[7].GetComponent<Image>().sprite = UnLockSprite[7];

        if (ScoreGame.GetComponent<GameManager>().MaxScore > 45000)
            CollectionGame[8].GetComponent<Image>().sprite = UnLockSprite[8];

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Cancle()
    {
        SceneManager.LoadScene(0);
    }
}
