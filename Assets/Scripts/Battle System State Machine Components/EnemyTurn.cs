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
        Debug.Log("The enemy is taking its turn");
        yield return new WaitForSeconds(2);
        BattleSystem.SetState(new BeginBattle(BattleSystem));
    }

    public override IEnumerator Attack()
    {
        Debug.Log("The enemy is attacking");
        yield break;
    }
}
