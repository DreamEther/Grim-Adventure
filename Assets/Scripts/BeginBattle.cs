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
        yield return new WaitForSeconds(2f);
        BattleSystem.SetState(new PlayerTurn(BattleSystem));
    }

    //this will be in another file

   
}
