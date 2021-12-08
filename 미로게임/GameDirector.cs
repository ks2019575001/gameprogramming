using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    float playTime = 60f;
    // Start is called before the first frame update
    public void OnClickMain()
    {
        Time.timeScale = 1;
        Timer.rTime = playTime;
        SceneManager.LoadScene("gametitle");
    }
    public void OnClickRetry()
    {
        Time.timeScale = 1;
        Timer.rTime = playTime;
        SceneManager.LoadScene("gamestage");
    }
}
