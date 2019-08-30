using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public static GameObject battleUI;
    public static GameObject combatLog;
    public static GameObject enemyGrid;
    public static GameObject laneTracks;

    void Awake()
    {
        battleUI = GameObject.FindGameObjectWithTag("BattleUI");
        combatLog = GameObject.FindGameObjectWithTag("CombatLog");
        enemyGrid = GameObject.FindGameObjectWithTag("EnemyGrid");
        laneTracks = GameObject.FindGameObjectWithTag("LaneTracks");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
