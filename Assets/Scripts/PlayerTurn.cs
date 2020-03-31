using System.Collections;
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
        Debug.Log("Choose an action...");
        yield break;
    }

    public override IEnumerator Attack()
    {
       
      // PlayAttackSequence(CharacterSpawner.playerOne, ninjaAttackSequence_1);
       // PlayNinjaRunAnim(CharacterSpawner.playerOne, ninjaRunAbility);
       UIController.battleUI.SetActive(false);
       UIController.combatLog.SetActive(false);
        
        bool temp = true;
        Debug.Log("I'm attacking");
        yield return new WaitForSeconds(5f);
        if(temp)
        {
            BattleSystem.SetState(new EnemyTurn(BattleSystem));
        }
    }
}
