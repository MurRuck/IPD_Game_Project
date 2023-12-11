using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RankinSceneUICtrl : MonoBehaviour
{
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        System.GC.Collect();
        text.text = GameObject.Find("SingleTon").gameObject.GetComponent<GameManager>().PlayerName + " " + GameObject.Find("SingleTon").gameObject.GetComponent<GameManager>().GameScore + "점";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
