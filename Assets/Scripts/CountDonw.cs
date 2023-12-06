using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDonw : MonoBehaviour
{
    float time = 3f;
    public GameObject CountGame;
    public Sprite[] CountSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;

        if (time > 2)
            CountGame.GetComponent<Image>().sprite = CountSprite[2];
        
        else if (time < 2 && time > 1)
            CountGame.GetComponent<Image>().sprite = CountSprite[1];
        
        else if (time < 1 && time > 0)
            CountGame.GetComponent<Image>().sprite = CountSprite[0];

        if (time <= 0)
            gameObject.SetActive(false);

    }
}
