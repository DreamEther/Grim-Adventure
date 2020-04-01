using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceMinionButtonClicked : MonoBehaviour
{
    [SerializeField] public bool placeMinionButtonClicked = false;

    public void PlaceMinionButtonClickedTrue()
    {
        placeMinionButtonClicked = true;
        UIController.minionUI.SetActive(true);
       // UIController.combatLog.SetActive(false);
    }
}
