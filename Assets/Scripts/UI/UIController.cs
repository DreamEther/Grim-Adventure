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
    public static GameObject ninjaRushUI;
    public static GameObject dragoonRushUI;


    void Awake()
    {
        battleUI = GameObject.FindGameObjectWithTag("BattleUI");
        combatLog = GameObject.FindGameObjectWithTag("CombatLog");
        enemyGrid = GameObject.FindGameObjectWithTag("EnemyGrid");
        laneTracks = GameObject.FindGameObjectWithTag("LaneTracks");
        minionUI = GameObject.FindGameObjectWithTag("MinionInventory");
        ninjaRushUI = GameObject.FindGameObjectWithTag("NinjaRushUI");
        dragoonRushUI = GameObject.FindGameObjectWithTag("DragoonRushUI");
    }

    private void Start()
    {
        ninjaRushUI.SetActive(false);
        dragoonRushUI.SetActive(false);
        minionUI.SetActive(false);
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            minionUI.SetActive(false);
        }
    }

    private void CloseAllUIInstances()
    {
        //minionUI.SetActive(false);
        //minionUI.SetActive(false);

        //minionUI.SetActive(false);
        ninjaRushUI.SetActive(false);
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
