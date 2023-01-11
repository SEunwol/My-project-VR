using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonPlayer : MonoBehaviour
{
    public static PhotonPlayer me;
    public PhotonView _photonView;
    public TextMeshProUGUI nickNamePlayerble;
    public string namelocal = "Local Name";
    public int numberCount = 0;
    protected virtual void LoadOwnerNickName()
    {
        this.nickNamePlayerble.text = this.namelocal + ": " + this.numberCount;
        if (this._photonView.ViewID == 0) return;
        this.namelocal = this._photonView.Owner.NickName;
    }
    protected virtual void OwnerController()
    {
        if (this._photonView.ViewID != 0 && !this._photonView.IsMine) return;

        
    }
    public virtual void Leave()
    {
        Debug.Log(transform.name + ": Leave Room");
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.LoadLevel("LoadingScene");
    }

    
}
