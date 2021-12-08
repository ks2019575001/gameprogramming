using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] GameObject gameovertext, mainbtn, retrybtn;
    Text text;
    public static float rTime = 60f;

    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        rTime -= Time.deltaTime;
        if (rTime < 0)
        {
            rTime = 0;
            Time.timeScale = 0;
            Gameover();
        }
        text.text = "TIME : " + Mathf.Round(rTime);
    }

    void Gameover()
    {
        gameovertext.SetActive(true);
        mainbtn.SetActive(true);
        retrybtn.SetActive(true);
    }
}
