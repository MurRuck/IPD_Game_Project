using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneCtrl : MonoBehaviour
{
    float time;
    float gauge;

    public GameObject TimeScoll;

    public GameManager manager;
    // Start is called before the first frame update'

    void Start()
    {
        System.GC.Collect();
        manager = GameObject.Find("SingleTon").GetComponent<GameManager>();
        time = Random.Range(3, 8);
        gauge = 1 / time;
        Invoke("SceneChange", time + 0.3f);
        time = 0;

    }

    // Update is called once per frame
    void Update()
    {
;       time += Time.deltaTime;

        TimeScoll.GetComponent<Scrollbar>().size = time * gauge;
    }

    void SceneChange()
    {
        StartCoroutine(LoadMyAsyncScene());
    }

    IEnumerator LoadMyAsyncScene()
    {
        AsyncOperation async = SceneManager.LoadSceneAsync("GameScene");

        while(!async.isDone)
        {
            yield return null;
        }
    }
}
