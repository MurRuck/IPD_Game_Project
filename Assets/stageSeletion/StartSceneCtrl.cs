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

    public AudioSource PlayMusic;

    public AudioClip[] BGMList;

    // Start is called before the first frame update
    void Start()
    {
        PlayMusic = GetComponent<AudioSource>();

        if(manager.BGMBool)
            PlayMusic.Play();
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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            text.text = "aaa";
            EnterName();
        }
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

    public void OnSound()
    {
        if (manager.EFFBool)
        {
            PlayMusic.clip = BGMList[0];
            PlayMusic.Play();
        }
    }
    public void GameStart()
    {
        OnSound();
        StartCoroutine(LoadMyAsyncScene("LoadingScene"));
    }

    public void CollectionScene()
    {
        OnSound();
        StartCoroutine(LoadMyAsyncScene("CollectionScene"));
    }
    public void RankingScene()
    {
        OnSound();
        StartCoroutine(LoadMyAsyncScene("Rank"));
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
