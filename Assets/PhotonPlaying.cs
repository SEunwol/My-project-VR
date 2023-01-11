using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhotonPlaying : MonoBehaviourPunCallbacks
{
    public static PhotonPlaying instance;
    public string photonPlayerName = "PhotonPlayer";
    public List<PlayerProfiles> players = new List<PlayerProfiles>();

    protected void Awake()
    {
        

        this.LoadRoomPlayers();
        this.SpawnPlayer();
    }

    protected virtual void SpawnPlayer()
    {
        Debug.Log("SpawnPlayer");
        if (PhotonNetwork.NetworkClientState != ClientState.Joined)
        {
            Invoke("SpawnPlayer", 1f);
            return;
        }

        GameObject playerObj = PhotonNetwork.Instantiate(this.photonPlayerName, Vector3.zero, Quaternion.identity);
        PhotonView photonView = playerObj.GetComponent<PhotonView>();
        if (photonView.IsMine)
        {
            PhotonPlayer photonPlayer = playerObj.GetComponent<PhotonPlayer>();
            PhotonPlayer.me = photonPlayer;
        }
    }


    protected virtual void LoadRoomPlayers()
    {
        Debug.Log("LoadRoomPlayers");
        if (PhotonNetwork.NetworkClientState != ClientState.Joined)
        {
            Invoke("LoadRoomPlayers", 1f);
            return;
        }

        PlayerProfiles playerProfile;
        foreach (KeyValuePair<int, Player> playerData in PhotonNetwork.CurrentRoom.Players)
        {
            //Debug.Log(playerData.Value.NickName);
            playerProfile = new PlayerProfiles
            {
                nickName = playerData.Value.NickName
            };
            this.players.Add(playerProfile);
        }
    }

    public virtual void Leave()
    {
        Debug.Log(transform.name + ": Leave Room");
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        Debug.Log(transform.name + ": OnLeftRoom");
        PhotonNetwork.LoadLevel("LoadingScene");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("OnPlayerEnteredRoom: " + newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("OnPlayerLeftRoom: " + otherPlayer.NickName);
    }
}
