using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{

    protected BattleSystem BattleSystem;

    //essentially using dependency injection so I can 
    public State(BattleSystem battleSystem)
    {
        BattleSystem = battleSystem;
    }
    // Start is called before the first frame update
    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator Attack()
    {
        yield break;
    }

    public virtual IEnumerator Heal()
    {
        yield break;
    }

    public virtual IEnumerator Defend()
    {
        yield break;
    }

    public virtual IEnumerator NextCharTurn()
    {
        yield break;
    }
}
