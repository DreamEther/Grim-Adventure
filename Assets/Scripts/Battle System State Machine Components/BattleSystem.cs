using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : StateMachine
{
    public delegate void OnTurnChange();
    public OnTurnChange TurnChanged;
    public GameObject ninja;
    public GameObject currentPlayer;
    public bool playAttackSequenceOne = false;
    //NEED TO MAKE WIN AND LOSE STATES. CAN DELETE ENUMS AFTER...JUST FOR REFERENCE
    public void Update()
    {
  
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
