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

    void Awake()
    {
        battleUI = GameObject.FindGameObjectWithTag("BattleUI");
        combatLog = GameObject.FindGameObjectWithTag("CombatLog");
        enemyGrid = GameObject.FindGameObjectWithTag("EnemyGrid");
        laneTracks = GameObject.FindGameObjectWithTag("LaneTracks");
        minionUI = GameObject.FindGameObjectWithTag("MinionInventory");
        rushUI = GameObject.FindGameObjectWithTag("RushInventory");
        minionUI.SetActive(false);
        rushUI.SetActive(false);
        combatLog.SetActive(false);

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            minionUI.SetActive(false);
        }
    }
}
