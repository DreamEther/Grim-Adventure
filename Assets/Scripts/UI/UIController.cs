using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static GameObject battleUI;
    public static GameObject combatLog;
    public static GameObject enemyGrid;
    public static GameObject laneTracks;
    public static GameObject minionUI;
    public static GameObject rushUI;
    private AttackSequence attackSequence;
    [SerializeField] public List<AttackSequence> ninjaAttackSequences;
    public static GameObject ninjaRushUI;
    void Awake()
    {
        battleUI = GameObject.FindGameObjectWithTag("BattleUI");
        combatLog = GameObject.FindGameObjectWithTag("CombatLog");
        enemyGrid = GameObject.FindGameObjectWithTag("EnemyGrid");
        laneTracks = GameObject.FindGameObjectWithTag("LaneTracks");
        minionUI = GameObject.FindGameObjectWithTag("MinionInventory");
        //rushUI = GameObject.FindGameObjectWithTag("RushInventory");
        minionUI.SetActive(false);
        //ninjaRushUI.SetActive(false);
        //combatLog.SetActive(false);
        ninjaAttackSequences = new List<AttackSequence>();
        ninjaRushUI = GameObject.FindGameObjectWithTag("NinjaRushUI");

    }

    private void Start()
    {
        ninjaRushUI.SetActive(false);
        //attackSequence = new NinjaAttackSequence2();
        //attackSequence.aName = "ninjaAS2";
        //attackSequence.isOfType = "ninjaAttackAnimation";
        //ninjaAttackSequences.Add(attackSequence);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            minionUI.SetActive(false);
        }
    }

    public void OpenNinjaRushUI()
    {
        ninjaRushUI.SetActive(true);
    }

    public void CloseNinjaRushUI()
    {
        ninjaRushUI.SetActive(false);
    }


    public void OpenDragoonRushUI()
    {

    }

    public void OpenNinjaMinionUI()
    {

    }
    public void OpenDragoonMinionUI()
    {

    }
}
