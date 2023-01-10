using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhotonRoom : MonoBehaviourPunCallbacks
{
    public static PhotonRoom instance;
    public TMP_InputField roomInput;
    public Transform roomContent;
    public UIRoomProfiles roomPrefabs;
    public List<RoomInfo> updateRoom;
    public List<RoomProfile> rooms = new List<RoomProfile>();
    // Start is called before the first frame update
    void Start()
    {
        PhotonRoom.instance = this;
        this.roomInput.text = "Room 1";
        this.UpdateRoomProfileUI();
    }

    public virtual void Creat()
    {
        string name = roomInput.text;
        Debug.Log(transform.name + ": Creat room " + name);
        PhotonNetwork.CreateRoom(name);
    }
    public virtual void Join()
    {
        string name = roomInput.text;
        Debug.Log(transform.name + ": Join room " + name);
        PhotonNetwork.JoinRoom(name);
        
    }
    public virtual void Leave()
    {
        Debug.Log(transform.name + ": Leave room ");
        PhotonNetwork.LeaveRoom();
    }
    public virtual void OnClickStartGame()
    {
        Debug.Log(transform.name + ": Click Start Game");
        if (PhotonNetwork.IsMasterClient) this.StartGame();
        else Debug.LogWarning("You are not Master Client");
    }
    public virtual void StartGame()
    {
        Debug.Log(transform.name + ": Start Game");
        PhotonNetwork.LoadLevel("Gameplay1");
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
    }
    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        Debug.Log("OnJoinedRoom");
        this.ClearRoomProfileUI();

    }
    public override void OnLeftRoom()
    {
        //base.OnLeftRoom();
        Debug.Log("OnLeftRoom");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log(transform.name + ": OnCreateRoomFailed: " + message);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //base.OnRoomListUpdate(roomList);
        Debug.Log(transform.name + ": OnRoomListUpdate");
        this.updateRoom = roomList;
        foreach(RoomInfo roomInfo in roomList)
        {
            if (roomInfo.RemovedFromList) this.RoomRemove(roomInfo);
            else this.RoomAdd(roomInfo);
        }
        this.UpdateRoomProfileUI();

    }
    protected virtual void RoomAdd(RoomInfo roomInfo)
    {
        RoomProfile roomProfile;    
        roomProfile = this.RoomByName(roomInfo.Name);
        if (roomProfile != null) return;

        roomProfile = new RoomProfile
        {
            name = roomInfo.Name
        };
        this.rooms.Add(roomProfile);
    }
    protected virtual void UpdateRoomProfileUI()
    {
        Debug.Log("UpdateRoomProfileUI");
        this.ClearRoomProfileUI();
        foreach (RoomProfile roomProfile in this.rooms)
        {
            UIRoomProfiles uiRoomProfile = Instantiate(this.roomPrefabs);
            uiRoomProfile.SetRoomProfile(roomProfile);
            uiRoomProfile.transform.SetParent(this.roomContent);
            
        }
    }
    protected virtual void ClearRoomProfileUI()
    {
        foreach (Transform child in this.roomContent)
        {
            Destroy(child.gameObject);
            
        }
    }

    protected virtual void RoomRemove(RoomInfo roomInfo)
    {
        RoomProfile roomProfile = this.RoomByName(roomInfo.Name);
        if (roomProfile == null) return;
        this.rooms.Remove(roomProfile);
    }
    protected virtual RoomProfile RoomByName(string name)
    {
        foreach (RoomProfile roomProfile in this.rooms)
        {
            if (roomProfile.name == name) return roomProfile;
        }
        return null;
    }

}
