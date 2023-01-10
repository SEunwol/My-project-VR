using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class PhotonStatusText : MonoBehaviour
{
    public string photonStatus;
    public TextMeshProUGUI textStatus;

    // Update is called once per frame
    void Update()
    {
        this.photonStatus = PhotonNetwork.NetworkClientState.ToString();
        this.textStatus.text = this.photonStatus;
    }
    
}
