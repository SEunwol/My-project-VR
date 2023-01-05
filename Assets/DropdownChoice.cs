using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class DropdownChoice : MonoBehaviour
{
    public ActionBasedSnapTurnProvider snapTurn;
    public ActionBasedContinuousTurnProvider normalTurn;

    public void SetTypeDropDown(int index)
    {
        if(index == 0)
        {
            snapTurn.enabled = false;
            normalTurn.enabled = true;
        }    
        else if(index == 1)
        {
            normalTurn.enabled = false;
            snapTurn.enabled = true;
        }    
    }    
}
