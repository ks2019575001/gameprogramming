using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleDirector : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnClickStart()
    {
        SceneManager.LoadScene("gamestage");
    }
    public void OnClickRule()
    {
        SceneManager.LoadScene("gamerule");
    }
    public void onClickExit()
    {
        Application.Quit(); // 어플리케이션 종료
    }
}
