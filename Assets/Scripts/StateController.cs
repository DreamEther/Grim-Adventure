using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StateController : MonoBehaviour
{
    PlayerController playerController;
    public static GameObject battleUI;
    public static GameObject combatLog;
    public static GameObject enemyGrid;
    private GameObject ninjaTag;
    private GameObject dragonTag;
    [SerializeField] Ability ninjaSlashAbility;
    [SerializeField] Ability ninjaRunAbility;
    bool beginRush = false;

    private UnityAction ninjaActions;
    private UnityAction draygonActions;

    public enum PlayerStates
    {
        PLAYERTURN,
        PLAYANIMATION,
        ENEMYTURN,
        LOSE,
        WIN
    }


    private PlayerStates currentState; 

    void Awake()
    {
        battleUI = GameObject.FindGameObjectWithTag("BattleUI");
        combatLog = GameObject.FindGameObjectWithTag("CombatLog");
        enemyGrid = GameObject.FindGameObjectWithTag("EnemyGrid");
    }



    // Start is called before the first frame update
    void Start()
    {
       // enemyGrid.SetActive(false);
        ninjaTag = GameObject.FindGameObjectWithTag("ninja"); // need to do this so we can determine how many, and which chars the player has in their party at the start of battle. 
        dragonTag = GameObject.FindGameObjectWithTag("draygon"); // need to do this so we can determine how many, and which chars the player has in their party at the start of battle.
        currentState = PlayerStates.PLAYERTURN;
    }

    // Update is called once per frame
    public void Update()
    {
        if (playerController == null)
        {
            playerController = FindObjectOfType<PlayerController>();
            return;
        }
        switch (currentState)
        {
            case PlayerStates.PLAYERTURN:
                {
                    switch (CharacterSpawner.playerOne.gameObject.tag)
                    {
                        case "ninja":
                            //GetCurrentSelectedChar("ninja");
                          
                            if (beginRush == true)
                            {
                                PlayNinjaSlashAnim(CharacterSpawner.playerOne, ninjaSlashAbility);
                                PlayNinjaRunAnim(CharacterSpawner.playerOne, ninjaRunAbility);
                                battleUI.SetActive(false);
                                combatLog.SetActive(false);
                            }
                        break;

                        case "draygon":
                            GetCurrentSelectedChar("draygon");
                        break;
                    }
                    break;
                }          
        }
    }

    public GameObject GetCurrentSelectedChar(string tag)
    {
        string charTag = tag;
        GameObject currentChar = GameObject.FindGameObjectWithTag(charTag);
        return currentChar;
    }

    public void BeginRushOnAttackSelect()
    {
        beginRush = true;
    }

    public void MovePlayer()
    {

    }

    public void PlayNinjaSlashAnim(GameObject playerChar, Ability ability)
    {

        ninjaSlashAbility = ability;
        ninjaSlashAbility.Initialize(playerChar); // getting the trigger component script attached to 'playerChar'
        ninjaSlashAbility.TriggerAbility();
    }

    public void PlayNinjaRunAnim(GameObject playerChar, Ability ability)
    {

        ninjaRunAbility = ability;
        ninjaRunAbility.Initialize(playerChar); // getting the trigger component script attached to 'playerChar'
        ninjaRunAbility.TriggerAbility();
    }





}
