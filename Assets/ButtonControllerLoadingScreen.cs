using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonControllerLoadingScreen : MonoBehaviour
{
    public GameObject creatButton;
    public GameObject joinButton;
    public GameObject startgameButton;
    public GameObject leaveButton;
    public GameObject lisRoom;

    public void OnClickCreat()
    {
        creatButton.SetActive(false);
        joinButton.SetActive(false);
        startgameButton.SetActive(true);
        leaveButton.SetActive(true);
    }
    public void OnClickJoin()
    {
        creatButton.SetActive(false);
        joinButton.SetActive(false);
        startgameButton.SetActive(true);
        leaveButton.SetActive(true);
    }
    public void OnClickLeave()
    {
        startgameButton.SetActive(false);
        lisRoom.SetActive(false);
        creatButton.SetActive(true);
        joinButton.SetActive(true);

    }
}
