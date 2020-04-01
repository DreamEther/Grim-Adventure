using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script and its method is referenced on the button for 'Move'
public class MoveButtonTrigger : MonoBehaviour
{
    [SerializeField] public bool moveButtonClicked = false;

    public void MoveButtonClicked()
    {
        moveButtonClicked = true;
       // UIController.combatLog.SetActive(false);
    }
}
