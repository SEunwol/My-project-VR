using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class GameMenuController : MonoBehaviour
{
    public GameObject gameMenu;
    public Transform headPlayer;
    PhotonPlayer photonPlayer;
    public float spawnDistance = 2;
    public InputActionProperty showButton;
    // Start is called before the first frame update
    void Start()
    {
        photonPlayer = headPlayer.GetComponent<PhotonPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(showButton.action.WasPressedThisFrame())
        {
            gameMenu.SetActive(!gameMenu.activeSelf);
            gameMenu.transform.position = headPlayer.position + new Vector3(headPlayer.forward.x, 0, headPlayer.forward.z).normalized * spawnDistance;
        }

        gameMenu.transform.LookAt(new Vector3 (headPlayer.position.x, gameMenu.transform.position.y, headPlayer.position.z));
        gameMenu.transform.forward *= -1;
    }
}
