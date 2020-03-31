using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurn : State
{
    public EnemyTurn(BattleSystem battleSystem) : base(battleSystem)
    {

    }

    // Start is called before the first frame update
    public override IEnumerator Start()
    {
        Debug.Log("I'm at the start of the enemy's turn");
        yield return new WaitForSeconds(3f);
        BattleSystem.SetState(new PlayerTurn(BattleSystem));
    }
}
