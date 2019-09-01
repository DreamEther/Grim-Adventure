using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterLane1 : MonoBehaviour
{
    public static List<GameObject> enemiesInLaneOne;
    public static List<GameObject> playerCharsInLaneOne;
    PlayerController playerChar;

    void Start()
    {
        playerChar = gameObject.GetComponent<PlayerController>();
        enemiesInLaneOne = new List<GameObject>();
        playerCharsInLaneOne = new List<GameObject>();
    }

    void Update()
    {
        if (playerChar == null)
        {
            playerChar = gameObject.GetComponent<PlayerController>();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerChar = other.gameObject.GetComponent<PlayerController>();
        if (other.gameObject.tag == "enemy")
        { 
          enemiesInLaneOne.Add(other.gameObject);
          Debug.Log(enemiesInLaneOne.Count);         
        }

        else if (playerChar.gameObject)
        {
            playerCharsInLaneOne.Add(playerChar.gameObject);
            Debug.Log(playerCharsInLaneOne.Count);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        playerChar = other.gameObject.GetComponent<PlayerController>();

        if (other.gameObject.tag == "enemy")
        {
            enemiesInLaneOne.Remove(other.gameObject);
            Debug.Log(enemiesInLaneOne.Count);
        }

        else if (playerChar.gameObject)
        {
            playerCharsInLaneOne.Remove(playerChar.gameObject);
            Debug.Log(playerCharsInLaneOne.Count);
        }
    }
}
