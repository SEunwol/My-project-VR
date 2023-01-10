using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Photon.Pun;
using TMPro;


public class UIControllerLoadingScene : MonoBehaviourPunCallbacks
{
    public GameObject loginStep;
    public GameObject login;
    public GameObject logout;
    public GameObject roomUI;
    public GameObject roomList;

    public TMP_InputField inputUserName;
    public TextMeshProUGUI userName;
    
    // Start is called before the first frame update
    void Start()
    {
        logout.SetActive(false);
        loginStep.SetActive(true);
        this.inputUserName.text = "1a";
    }

    public void OnclickLogin()
    {
        logout.SetActive(true);
        login.SetActive(false);
        
        //Debug.Log("Button");
    }
    public virtual void Login()
    {
        string name = inputUserName.text;
        this.userName.text = name;

        PhotonNetwork.LocalPlayer.NickName = name;
        PhotonNetwork.ConnectUsingSettings();
        

    }
    public virtual void Logout()
    {
        PhotonNetwork.Disconnect();
    }
    
    public override void OnConnectedToMaster()
    {
        //base.OnConnectedToMaster();
        Debug.Log("OnConnectedToMaster");
        PhotonNetwork.JoinLobby();
        
    }
    public override void OnJoinedLobby()
    {
        //base.OnJoinedLobby();
        Debug.Log("OnJoinedLobby");
        roomUI.SetActive(true);
        loginStep.SetActive(false);
        roomList.SetActive(true);
    }

}
