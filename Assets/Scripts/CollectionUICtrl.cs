using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CollectionUICtrl : MonoBehaviour
{
    public Sprite[] UnLockSprite;
    public Sprite[] InformationSprite;
    public GameObject[] CollectionGame;
    public GameObject ScoreGame;

    public GameObject InforGame;

    bool[] UnlockBool = new bool[9];
    // Start is called before the first frame update
    void Start()
    {
        ScoreGame = GameObject.Find("SingleTon");

        if (ScoreGame.GetComponent<GameManager>().MaxScore > 5000)
        {
            CollectionGame[0].GetComponent<Image>().sprite = UnLockSprite[0];
            UnlockBool[0] = true;
        }
        if (ScoreGame.GetComponent<GameManager>().MaxScore > 10000)
        {
            CollectionGame[1].GetComponent<Image>().sprite = UnLockSprite[1];
            UnlockBool[1] = true;
        }
        if (ScoreGame.GetComponent<GameManager>().MaxScore > 15000)
        {
            CollectionGame[2].GetComponent<Image>().sprite = UnLockSprite[2];
            UnlockBool[2] = true;
        }
        if (ScoreGame.GetComponent<GameManager>().MaxScore > 20000)
        {
            CollectionGame[3].GetComponent<Image>().sprite = UnLockSprite[3];
            UnlockBool[3] = true;
        }
        if (ScoreGame.GetComponent<GameManager>().MaxScore > 25000)
        {
            CollectionGame[4].GetComponent<Image>().sprite = UnLockSprite[4];
            UnlockBool[4] = true;
        }
        if (ScoreGame.GetComponent<GameManager>().MaxScore > 30000)
        {
            CollectionGame[5].GetComponent<Image>().sprite = UnLockSprite[5];
            UnlockBool[5] = true;
        }
        if (ScoreGame.GetComponent<GameManager>().MaxScore > 35000)
        {
            CollectionGame[6].GetComponent<Image>().sprite = UnLockSprite[6];
            UnlockBool[6] = true;
        }
        if (ScoreGame.GetComponent<GameManager>().MaxScore > 40000)
        {
            CollectionGame[7].GetComponent<Image>().sprite = UnLockSprite[7];
            UnlockBool[7] = true;
        }
        if (ScoreGame.GetComponent<GameManager>().MaxScore > 45000)
        {
            CollectionGame[8].GetComponent<Image>().sprite = UnLockSprite[8];
            UnlockBool[8] = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Cancle()
    {
        SceneManager.LoadScene(0);
    }

    public void InforButton(int i)
    {
        if(UnlockBool[i])
        {
            InforGame.SetActive(true);
            InforGame.transform.GetChild(0).GetComponent<Image>().sprite = InformationSprite[i];
        }
    }

    public void OffInfor()
    {
        InforGame.SetActive(false);
    }
}
