using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonTrigger : MonoBehaviour
{
    [SerializeField] public bool moveButtonClicked = false;

    public void MoveButtonClicked()
    {
        moveButtonClicked = true;
       // UIController.combatLog.SetActive(false);
    }
}
