using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class clock : MonoBehaviour
{
    public Text clockText;
    //public GameObject clockText;
    public double seconds;
    public double fullSeconds;
    public bool isStarted;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isStarted)
        {
            return;
        }
        fullSeconds = Convert.ToInt32(seconds);
        clockText.GetComponent<Text>().text = $"{fullSeconds} сек.";
        seconds += 0.02;
    }    
}
