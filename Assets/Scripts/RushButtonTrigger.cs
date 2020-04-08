using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushButtonTrigger : MonoBehaviour
{
    [SerializeField] public bool placeRushButtonClicked = false;


    public void Toggle()
    {
        placeRushButtonClicked = true;
    }
    //public void OpenNinjaRushMenu()
    //{
    //    UIController.ninjaRushUI.SetActive(true);
    //    // UIController.combatLog.SetActive(false);
    //}

    //public void OpenDragoonRushMenu()
    //{
    //    UIController.ninjaRushUI.SetActive(true);
    //    // UIController.combatLog.SetActive(false);
    //}
}
