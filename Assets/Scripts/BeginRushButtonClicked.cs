using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginRushButtonClicked : MonoBehaviour
{
    [SerializeField] public bool placeRushButtonClicked = false;

    public void OpenNinjaRushMenu()
    {
        UIController.ninjaRushUI.SetActive(true);
        // UIController.combatLog.SetActive(false);
    }
}
