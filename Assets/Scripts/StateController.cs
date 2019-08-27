using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateController : MonoBehaviour
{
    PlayerController playerController;
    GameObject battleUI;
    Rect rect;
    [SerializeField] GameObject ninja;
    private GameObject ninjaTag;
    private GameObject dragonTag;
    [SerializeField] Ability ninjaSlashAbility;
    [SerializeField] Texture buttonTexture;
    bool beginRush = false;

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
    }



    // Start is called before the first frame update
    void Start()
    {
        InitializeNinjaSlashAnim(ninja, ninjaSlashAbility);
        ninjaTag = GameObject.FindGameObjectWithTag("ninja"); // need to do this so we can determine how many, and which chars the player has in their party at the start of battle. 
        dragonTag = GameObject.FindGameObjectWithTag("dragon"); // need to do this so we can determine how many, and which chars the player has in their party at the start of battle.
      //  playerController = FindObjectOfType<PlayerController>();
        rect = new Rect(800, 130.2f, 160, 30);

        currentState = PlayerStates.PLAYERTURN;
    }

    // Update is called once per frame
    public void Update()
    {
        if (playerController == null)
        {
            Debug.Log("Located PlayerControllerComponent");
            playerController = FindObjectOfType<PlayerController>();
            return;
        }
        switch (currentState)
        {
            case PlayerStates.PLAYERTURN:
                {
                    battleUI.SetActive(true);

                    switch (CharacterSpawner.playerOne.gameObject.tag)
                    {
                        case "ninja":
                            if (beginRush == true)
                            {
                                ninjaSlashAbility.TriggerAbility();
                                playerController.PlayRunAnim();
                                battleUI.SetActive(false);
                            }
                        break;
                    }
                    break;
                }
             
             

                
        }
    }

    public void BeginRush()
    {
        beginRush = true;
    }
    void OnGUI()
    {
        //GUI.Button(new Rect(50, 130.2f, 160, 30), buttonTexture);
        //GUI.DrawTexture(rect, buttonTexture);
       
    }

    public void InitializeNinjaSlashAnim(GameObject playerChar, Ability ability)
    {

        ninjaSlashAbility = ability;
        ninjaSlashAbility.Initialize(playerChar); // getting the trigger component script attached to 'playerChar'

    }


}
