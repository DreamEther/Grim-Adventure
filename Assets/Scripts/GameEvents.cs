using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{

    private Enemy[] enemies;
    private PlayerController[] players;
    public List<GameObject> enemiesInScene = new List<GameObject>();
    public List<GameObject> playersInScene = new List<GameObject>();
    private static GameEvents _instance;
    public List<GameObject> storeAllCharsAsObjects;

    // Start is called before the first frame update
    public static GameEvents Instance
    {
     get {
         if (_instance == null)
         {
             _instance = GameObject.FindObjectOfType<GameEvents>();
             
             if (_instance == null)
             {
                 GameObject container = new GameObject("Event System");
                 _instance = container.AddComponent<GameEvents>();
             }
         }
     
         return _instance;
         }
    }



    void Awake()
    {
        storeAllCharsAsObjects = new List<GameObject>();
        enemies = FindObjectsOfType<Enemy>();
        players = FindObjectsOfType<PlayerController>();
        GetEnemiesInScenes();
        Debug.Log("enemies in scene" + enemiesInScene.Count);
        GetPlayersInScenes();
        storeAllCharsAsObjects.AddRange(enemiesInScene);
        storeAllCharsAsObjects.AddRange(playersInScene);
        _instance = this;
    }
    void Start()
    {

        TurnOrder.presentInScene.AddRange(storeAllCharsAsObjects);
        Debug.Log("present in scene count: " + TurnOrder.presentInScene.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   void GetEnemiesInScenes()
    {
        foreach (Enemy enemy in enemies)
        {
            enemiesInScene.Add(enemy.gameObject);
        }       
    }

    void GetPlayersInScenes()
    {
        foreach (PlayerController player in players)
        {
            playersInScene.Add(player.gameObject);
        }
    }
}
