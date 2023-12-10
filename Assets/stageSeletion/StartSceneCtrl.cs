using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartSceneCtrl : MonoBehaviour
{
    public GameObject TouchStartGame;
    public GameObject EnterYourName;
    public GameObject[] Buttons;

    public TextMeshProUGUI text;

    public bool StartOK = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(text.text.Length != 1)
            EnterYourName.transform.GetChild(2).gameObject.SetActive(false);

        else
            EnterYourName.transform.GetChild(2).gameObject.SetActive(true);

        if (text.text.Contains(" "))
            StartOK = false;
        else
            StartOK = true;
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void CollectionScene()
    {
        SceneManager.LoadScene(4);
    }
    public void RankingScene()
    {
        SceneManager.LoadScene(5);
    }

    public void TouchScreen()
    {
        TouchStartGame.SetActive(false);
        if(GameObject.Find("SingleTon").GetComponent<GameManager>().PlayerName == "")
            EnterYourName.SetActive(true);
        else
        {
            Buttons[0].SetActive(true);
            Buttons[1].SetActive(true);
        }
    }

    public void EnterName()
    {
        if(text.text.Length != 1 && StartOK)
        {
            EnterYourName.SetActive(false);
            Buttons[0].SetActive(true);
            Buttons[1].SetActive(true);

            GameObject.Find("SingleTon").GetComponent<GameManager>().PlayerName = text.text;
        }

    }
}
