using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterLane2 : MonoBehaviour
{
    public static List<GameObject> enemiesInLaneTwo;
    public static List<GameObject> playerCharsInLaneTwo;
    private PlayerController playerChar;

    PlayerController.LanePosition lane2;
    PlayerController.LanePosition noLane;

    void Start()
    // {
    //     if(playerChar == null)
    //     {
    //         playerChar = gameObject.GetComponent<PlayerController>();
    //     }
    {
        enemiesInLaneTwo = new List<GameObject>();
        if (playerCharsInLaneTwo == null)
        {
            playerCharsInLaneTwo = new List<GameObject>();
        }
        lane2 = PlayerController.LanePosition.LANE2;
        noLane = PlayerController.LanePosition.NULL;
    }

    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerChar = other.gameObject.GetComponent<PlayerController>();
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (playerChar != null)
        {
            TurnOrder.presentInScene.Add(playerChar.gameObject);

            playerCharsInLaneTwo.Add(playerChar.gameObject);
            playerChar.isMyTurn = false;
            //TurnOrder.presentInScene.Add(playerChar.gameObject);
            playerChar.UpdateLane(lane2);
            // foreach(GameObject player in playerCharsInLaneOne)
            // {
            //    playerChar.UpdateLane(lane1);
            // }
            Debug.Log("Player chars in lane 2: " + playerCharsInLaneTwo.Count);
            Debug.Log("Player Char current Position: " + playerChar.CurrentPosition);

        }
        //PlayerController.LanePosition.LANE1;
        if (other.gameObject.tag == "enemy")
        {
            TurnOrder.presentInScene.Add(other.gameObject);
            enemy.SetCurrentLane(1);
            enemy.isMyTurn = false;
            enemiesInLaneTwo.Add(other.gameObject);
           // TurnOrder.presentInScene.Add(other.gameObject);

            //   foreach(GameObject enemy in enemiesInLaneOne)
            //   {
            //      // Debug.Log(enemy.name);
            Debug.Log(enemiesInLaneTwo.Count);
            //   }       
        }



        // return noLane.ToString();

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerChar = other.gameObject.GetComponent<PlayerController>();

        if (other.gameObject.tag == "enemy")
        {
            enemiesInLaneTwo.Remove(other.gameObject);
            Debug.Log(enemiesInLaneTwo.Count);
        }

        else if (playerChar.gameObject != null)
        {
            playerCharsInLaneTwo.Remove(playerChar.gameObject);
            Debug.Log(playerCharsInLaneTwo.Count);
        }
    }
}