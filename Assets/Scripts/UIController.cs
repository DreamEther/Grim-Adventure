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
    void Awake()
    {
        battleUI = GameObject.FindGameObjectWithTag("BattleUI");
        combatLog = GameObject.FindGameObjectWithTag("CombatLog");
        enemyGrid = GameObject.FindGameObjectWithTag("EnemyGrid");
        laneTracks = GameObject.FindGameObjectWithTag("LaneTracks");
        minionUI = GameObject.FindGameObjectWithTag("MinionInventory");
        rushUI = GameObject.FindGameObjectWithTag("RushInventory");
        //minionUI.SetActive(false);
        //rushUI.SetActive(false);
        //combatLog.SetActive(false);
        ninjaAttackSequences = new List<AttackSequence>();

    }

    private void Start()
    {

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
}
