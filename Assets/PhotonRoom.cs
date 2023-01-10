using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhotonRoom : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomInput;
    public Transform roomContent;
    public UIRoomProfiles roomPrefabs;
    public List<RoomInfo> updateRoom;
    public List<RoomProfile> rooms = new List<RoomProfile>();
    // Start is called before the first frame update
    void Start()
    {
        this.roomInput.text = "Room 1";
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
        this.ClearRoomProfileUI();
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("OnCreatedRoom");
    }
    public override void OnJoinedRoom()
    {
        //base.OnJoinedRoom();
        Debug.Log("OnJoinedRoom");
    }
    public override void OnLeftRoom()
    {
        //base.OnLeftRoom();
        Debug.Log("OnLeftRoom");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        //base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("OnCreateRoomFailed: " + message);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        //base.OnRoomListUpdate(roomList);
        Debug.Log(transform.name + ": OnRoomListUpdate");
        this.updateRoom = roomList;
        foreach(RoomInfo roomInfo in roomList)
        {
            Debug.Log("OnRoomListUpdate fore each");
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
