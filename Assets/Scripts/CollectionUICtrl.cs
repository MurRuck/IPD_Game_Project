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
    public GameManager ScoreGame;

    public GameObject InforGame;

    bool[] UnlockBool = new bool[9];
    // Start is called before the first frame update
    void Start()
    {
        System.GC.Collect();
        ScoreGame = GameObject.Find("SingleTon").GetComponent<GameManager>();


        for(int i = 0; i < ScoreGame.MaxScore / 5000; i++)
        {
            CollectionGame[i].GetComponent<Image>().sprite = UnLockSprite[i];
            UnlockBool[i] = true;
        }
    }
    public void Cancle()
    {
        StartCoroutine(LoadMyAsyncScene("MainScene"));
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

    IEnumerator LoadMyAsyncScene(string SceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(SceneName);

        while (!async.isDone)
        {
            yield return null;
        }
    }
}
