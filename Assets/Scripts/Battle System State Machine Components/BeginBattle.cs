using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginBattle : State
{
    public BeginBattle(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    //own start method which other states will also implement
    public override IEnumerator Start()
    {
        Debug.Log("In begin battle start method");
        yield return new WaitForSeconds(1f);

        BattleSystem.currentPlayer = TurnOrder.turnOrder.Dequeue();
        Debug.Log("currentPlayer" + BattleSystem.currentPlayer.name);
        if (BattleSystem.currentPlayer.GetComponent<Enemy>() == null)
        {
            BattleSystem.SetState(new PlayerTurn(BattleSystem));
        }
        else if (BattleSystem.currentPlayer.GetComponent<PlayerController>() == null)
        {
            BattleSystem.SetState(new EnemyTurn(BattleSystem));
        }
            
    }

    //this will be in another file

   
}
