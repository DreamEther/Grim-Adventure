﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : State
{
    // Specifies which base-class constructor should be called when 
    //creating instances of the derived class.

    //Call also be used to call a method on the base class that has been overridden by another method.


    public PlayerTurn(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    // Start is called before the first frame update
    public override IEnumerator Start()
    {
        if (BattleSystem.currentPlayer.GetComponent<PlayerController>() != null)
        {
            UIController.combatLog.SetActive(true);
            Debug.Log("Choose an action...");
            yield break;
        }

    }

    public override IEnumerator Attack()
    {
        BattleSystem.currentPlayer.GetComponent<PlayerController>().isAttacking = true;
        Debug.Log("I'm attacking");
        //isMyTurn never turns false as of right now 
        yield return new WaitUntil(() => BattleSystem.currentPlayer.GetComponent<PlayerController>().isMyTurn == false);
        BattleSystem.currentPlayer.GetComponent<PlayerController>().isAttacking = false;
        BattleSystem.SetState(new BeginBattle(BattleSystem));    
    }

}
