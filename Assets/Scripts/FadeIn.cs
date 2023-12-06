using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    float i = 0;
    bool FadeBool = false;
    float time = 4f;
    public GameObject[] FadeGame;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            FadeGame[1].SetActive(true);
            StartCoroutine("fade");
        }
    }

    private IEnumerator fade()
    {
        FadeGame[0].GetComponent<Image>().color = new Color(FadeGame[0].GetComponent<Image>().color.r, FadeGame[0].GetComponent<Image>().color.g, FadeGame[0].GetComponent<Image>().color.b, i);
        i+= 0.01f;
        yield return 0.1f;
    }
}
