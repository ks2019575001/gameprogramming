using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MouseEvent : MonoBehaviour
{
    [SerializeField] GameObject successtext, mainbtn, retrybtn, boxclose, boxopen;
    Camera _mainCam = null;
    // Start is called before the first frame update
    void Start()
    {
        _mainCam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(_mainCam.ScreenPointToRay(Input.mousePosition),out hit, 100.0f))
        {
            if(hit.collider.gameObject.tag == "Finish")
            {
                if(Input.GetMouseButtonDown(0))
                {
                    boxclose.SetActive(false);
                    boxopen.SetActive(true);
                    Time.timeScale = 0;
                    Success();
                }
            }
        }
        
    }
    void Success()
    {
        successtext.SetActive(true);
        mainbtn.SetActive(true);
        retrybtn.SetActive(true);
    }
}
