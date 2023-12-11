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

    public TMP_InputField text;

    public string inputtext;

    public bool StartOK = true;
    private TouchScreenKeyboard keyboard;

    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        System.GC.Collect();
        manager = GameObject.Find("SingleTon").GetComponent<GameManager>();
        if (manager.PlayerName != "")
        {
            TouchStartGame.SetActive(false);
            EnterYourName.SetActive(false);
            Buttons[0].SetActive(true);
            Buttons[1].SetActive(true);

        }
    }

    void BlankCheck()
    {
        if (text.text.Contains(" "))
            StartOK = false;
        else
            StartOK = true;


        if(text.text != "")
            EnterYourName.transform.GetChild(2).gameObject.SetActive(false);
        else
            EnterYourName.transform.GetChild(2).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        BlankCheck();

        if (text.isFocused)
        {
            if (keyboard.status == TouchScreenKeyboard.Status.Done && text.text != "")
                EnterName();
            else if(keyboard.status == TouchScreenKeyboard.Status.Done)
            {
                keyboard = null;
                keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
            }

        }


        if (EnterYourName.activeSelf && keyboard != null)
            text.text = keyboard.text;

    }

    public void GameStart()
    {
        manager.GoCollection = false;
        SceneManager.LoadScene(1);
    }

    public void CollectionScene()
    {
        manager.GoCollection = true;
        SceneManager.LoadScene(1);
    }
    public void RankingScene()
    {
        SceneManager.LoadScene(5);
    }

    public void TouchScreen()
    {
        TouchStartGame.SetActive(false);
        if (manager.PlayerName == "")
        {
            EnterYourName.SetActive(true);
            keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);

        }
        else
        {
            Buttons[0].SetActive(true);
            Buttons[1].SetActive(true);
        }
    }

    public void EnterName()
    {
        if (text.text.Length != 0 && StartOK)
        {
            EnterYourName.SetActive(false);
            Buttons[0].SetActive(true);
            Buttons[1].SetActive(true);
            manager.PlayerName = text.text;

            keyboard.active = false;
            keyboard = null;
        }

    }

}
