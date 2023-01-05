using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ActiveTeleportationRay : MonoBehaviour
{
    [SerializeField]
    public GameObject leftTeleportation;
    [SerializeField]
    public GameObject rightTeleportation;

    [SerializeField]
    public InputActionProperty leftActive;
    [SerializeField]
    public InputActionProperty rightActive;
    [SerializeField]
    public InputActionProperty leftCancel;
    [SerializeField]
    public InputActionProperty rightCancel;

    public XRRayInteractor leftRay;
    public XRRayInteractor rightRay;

    // Update is called once per frame
    void Update()
    {
        bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftpos, out Vector3 leftNormal, out int leftNumber, out bool leftVaild);
        leftTeleportation.SetActive(!isLeftRayHovering && leftCancel.action.ReadValue<float>() == 0 &&  leftActive.action.ReadValue<float>() > 0.1f);
        bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightpos, out Vector3 rightNormal, out int rightNumber, out bool rightVaild);
        rightTeleportation.SetActive(!isRightRayHovering && rightCancel.action.ReadValue<float>() == 0 &&  rightActive.action.ReadValue<float>() > 0.1f);
    }
}
