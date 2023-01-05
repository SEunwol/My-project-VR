using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActive : MonoBehaviour
{
    [SerializeField]
    public GameObject bullet;
    [SerializeField]
    public Transform bulletShoot;
    [SerializeField]
    public float fireSpeed;
    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FireBullet(ActivateEventArgs args)
    {
        GameObject bulletSpawn = Instantiate(bullet);
        bulletSpawn.transform.position = bulletShoot.position;
        bulletSpawn.GetComponent<Rigidbody>().velocity = bulletShoot.forward * fireSpeed;
        Destroy(bulletSpawn, 5);
    }
}
