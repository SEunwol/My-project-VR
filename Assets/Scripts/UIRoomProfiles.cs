using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class UIRoomProfiles : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI roomName;
    [SerializeField] protected RoomProfile roomProfile;


    public virtual void SetRoomProfile(RoomProfile roomProfile)
    {
        this.roomProfile = roomProfile; 
        this.roomName.text = this.roomProfile.name;
    }
    public virtual void OnClick()
    {
        Debug.Log("OnClick: " + this.roomProfile.name);
        PhotonRoom.instance.roomInput.text = this.roomProfile.name;
    }
}
