using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuButtonController : MonoBehaviour
{
    public GameObject dontPressThisButton;
    public GameObject reallyButton;
    public GameObject byeButton;
    
    // Start is called before the first frame update
    void Start()
    {
        dontPressThisButton.SetActive(true);
        reallyButton.SetActive(false);
        byeButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickDontPress()
    {
        dontPressThisButton.SetActive(false);
        reallyButton.SetActive(true);
    }
    public void OnClickReally()
    {
        reallyButton.SetActive(false);
        byeButton.SetActive(true);
    }
    public void OnClickBye()
    {
        Application.Quit();
    }    
}
