using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : StateMachine
{
    public GameObject ninja;
    public GameObject currentPlayer;
    public bool playAttackSequenceOne = false;
    //NEED TO MAKE WIN AND LOSE STATES. CAN DELETE ENUMS AFTER...JUST FOR REFERENCE
    public enum BattleState
    {
        BEGINNING,
        PLAYERTURN,
        ENEMYTURN,
        WIN,
        LOSE
    }

    public void Update()
    {
       if(playAttackSequenceOne)
        {
            PlayAttackSequence(currentPlayer, ninjaAttackSequence_1);
        }
    }
    public void PlayAttackSequence(GameObject playerChar, AttackSequence attackSequence)
    {

        ninjaAttackSequence_1 = attackSequence;
        ninjaAttackSequence_1.Initialize(playerChar); // getting the trigger component script attached to 'playerChar'
        ninjaAttackSequence_1.TriggerAbility();
    }


    //won't need to include this since we are transitioning to new enum states in our specific state classes. 
    //public BattleState _state;
    public void Start()
    {
        //currentPlayer = new GameObject();
        ninja = GameObject.FindGameObjectWithTag("ninja");
        UIController.battleUI.SetActive(true);
        UIController.combatLog.SetActive(true);
        //_state = BattleState.BEGINNING;
        SetState(new BeginBattle(this));
    }

    public void OnAttack()
    {
       // if (_state != BattleState.PLAYERTURN) return;
        StartCoroutine(State.Attack());
    }

    public void OnDefend()
    {
        //if (_state != BattleState.PLAYERTURN) return;
        StartCoroutine(State.Defend());
    }

    public void OnHeal()
    {
       // if (_state != BattleState.PLAYERTURN) return;
        StartCoroutine(State.Heal());
    }

    
}
