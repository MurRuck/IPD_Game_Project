using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneCtrl : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(3, 8);
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("SceneChange", time);
    }

    void SceneChange()
    {
        SceneManager.LoadScene(2);
    }
}
