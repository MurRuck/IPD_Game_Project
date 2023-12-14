using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doneEffectParent : MonoBehaviour
{

    public float fadeSpeed;

    public Sprite spr;

    void Start()
    {

        if (transform.GetComponentInParent<TimeCheck>().time <= 30)
            GetComponent<AudioSource>().Play();
    }


}
