using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int index;

    public bool isForwardWall = true;
    public bool isBackWall = true;
    public bool isLeftWall = true;
    public bool isRightWall = true;

    public GameObject forwardwall;
    public GameObject backwall;
    public GameObject leftwall;
    public GameObject rightwall;


    // Start is called before the first frame update
    void Start()
    {
        ShowWalls();
    }

    public void ShowWalls()
    {
        forwardwall.SetActive(isForwardWall);
        backwall.SetActive(isBackWall);
        leftwall.SetActive(isLeftWall);
        rightwall.SetActive(isRightWall);
    }

    public bool CheckAllWall()
    {
        return isForwardWall && isBackWall && isLeftWall && isRightWall;
    }
}
