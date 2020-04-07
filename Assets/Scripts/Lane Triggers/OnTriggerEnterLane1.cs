using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterLane1 : MonoBehaviour
{
    public static Queue<GameObject> startingOrder;
    public static List<GameObject> enemiesInLaneOne;
    public static List<GameObject> playerCharsInLaneOne;
    private PlayerController playerChar;
    private Enemy enemy;
    PlayerController.LanePosition lane1;
     PlayerController.LanePosition noLane;
    void Start()
    {
        //startingOrder = new Queue<GameObject>(presentInScene);
        enemiesInLaneOne = new List<GameObject>();
        if(playerCharsInLaneOne == null)
        {    
             playerCharsInLaneOne = new List<GameObject>();
        }
        lane1 = PlayerController.LanePosition.LANE1;
        noLane = PlayerController.LanePosition.NULL;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        playerChar = other.gameObject.GetComponent<PlayerController>();
        enemy = other.gameObject.GetComponent<Enemy>();
        //TurnOrder.presentInScene.Add(playerChar.gameObject);

        if (playerChar != null)
        {
      
            // adding player friendly gameobject to global list in TurnOrder class every time this if statement is triggered
            // adding player Char to global lane  
            playerCharsInLaneOne.Add(playerChar.gameObject);
            playerChar.UpdateLane(lane1);
      
            Debug.Log("OnTriggerEnter for Player Called. Player chars in lane 1: " + playerCharsInLaneOne.Count);
            Debug.Log("Player Char current Position: " + playerChar.CurrentPosition);
        
        }
        if (other.gameObject.tag == "enemy")
        {
            // adding enemy gameobject to global list in Turn Order class every time this if statement is triggered
            enemy.SetCurrentLane(1);
            enemiesInLaneOne.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerChar = other.gameObject.GetComponent<PlayerController>();
        playerChar.newNearestGameObject = null;
        playerCharsInLaneOne.Remove(playerChar.gameObject);

        if (other.gameObject.tag == "enemy")
        {
            enemiesInLaneOne.Remove(other.gameObject);
            Debug.Log(enemiesInLaneOne.Count);
        }

        //else if (playerChar.gameObject != null)
        //{
        //    playerCharsInLaneOne.Remove(playerChar.gameObject);
        //    Debug.Log("OnTriggerExit for player called. Lane One count is: " + playerCharsInLaneOne.Count);
        //}
    }
}
