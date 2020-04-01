using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class StateMachine: MonoBehaviour
{
    [SerializeField] public AttackSequence ninjaAttackSequence_1;

    protected State State;
    private bool beginRush = true;
    public void SetState(State state)
    {
        State = state;
        StartCoroutine(State.Start());
    }

    


    //int nextCharTurn;
    //private GameObject ninjaTag;
    //private GameObject dragonTag;
    //[SerializeField] AttackSequence ninjaAttackSequence_1;
    //bool beginRush = false;

    //PlayerParty playerPartyList;
    //private UnityAction ninjaActions;
    //private UnityAction draygonActions;

    //public enum PlayerStates
    //{
    //    PLAYERTURN,
    //    PLAYANIMATION,
    //    ENEMYTURN,
    //    LOSE,
    //    WINo
    //}


    //private PlayerStates currentState; 

    //// Start is called before the first frame update
    //void Start()
    //{
    //   // enemyGrid.SetActive(false);
    //    ninjaTag = GameObject.FindGameObjectWithTag("ninja"); // need to do this so we can determine how many, and which chars the player has in their party at the start of battle. 
    //    dragonTag = GameObject.FindGameObjectWithTag("draygon"); // need to do this so we can determine how many, and which chars the player has in their party at the start of battle.
    //    currentState = PlayerStates.PLAYERTURN;

    //    playerPartyList = PlayerParty.FindObjectOfType<PlayerParty>();
    //}

    //// Update is called once per frame
    //public void Update()
    //{

    //    switch (currentState)
    //    {
    //        case PlayerStates.PLAYERTURN:
    //            {
    //                // need to change this and instead grab the PlayerParty List instead, and then use a switch based on that GameObjects tag. Then in enemyState before we switch back to playerTurn, we'll increment the partyList by one

    //                switch(playerPartyList.characters[0].gameObject.tag)
    //                { 

    //                    case "ninja":
    //                        //GetCurrentSelectedChar("ninja");

    //                        if (beginRush == true)
    //                        {
    //                            PlayAttackSequence(CharacterSpawner.playerOne, ninjaAttackSequence_1);
    //                           // PlayNinjaRunAnim(CharacterSpawner.playerOne, ninjaRunAbility);
    //                            UIController.battleUI.SetActive(false);
    //                            UIController.combatLog.SetActive(false);
    //                        }
    //                    break;

    //                    case "draygon":
    //                        GetCurrentSelectedChar("draygon");
    //                    break;
    //                }
    //                break;                 
    //            }
    //        case PlayerStates.ENEMYTURN:
    //        break;
    //    }
    //}

    //public GameObject GetCurrentSelectedChar(string tag)
    //{
    //    string charTag = tag;
    //    GameObject currentChar = GameObject.FindGameObjectWithTag(charTag);
    //    return currentChar;
    //}

    //public void BeginRushOnAttackSelect() //Calling this method in the inspector on our Attack button.
    //{
    //    beginRush = true;
    //}

    //public void MovePlayer()
    //{

    //}

    //public void PlayAttackSequence(GameObject playerChar, AttackSequence attackSequence)
    //{

    //    ninjaAttackSequence_1 = attackSequence;
    //    ninjaAttackSequence_1.Initialize(playerChar); // getting the trigger component script attached to 'playerChar'
    //    ninjaAttackSequence_1.TriggerAbility();
    //}

    /* public void PlayNinjaRunAnim(GameObject playerChar, Ability ability)
     {

         ninjaRunAbility = ability;
         ninjaRunAbility.Initialize(playerChar); // getting the trigger component script attached to 'playerChar'
         ninjaRunAbility.TriggerAbility();
     }*/





}
