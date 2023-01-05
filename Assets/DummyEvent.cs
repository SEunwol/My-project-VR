using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyEvent : MonoBehaviour
{
    public GameObject dummyEvent;
    public GameObject npcEvent;

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Check event in");
        dummyEvent.SetActive(false);
        npcEvent.SetActive(true);
    }

}
