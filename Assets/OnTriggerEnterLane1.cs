using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterLane1 : MonoBehaviour
{
    public static List<GameObject> enemiesInLaneOne;

    void Start()
    {
        enemiesInLaneOne = new List<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        { 
          enemiesInLaneOne.Add(other.gameObject);
          Debug.Log(enemiesInLaneOne.Count);         
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            enemiesInLaneOne.Remove(other.gameObject);
            Debug.Log(enemiesInLaneOne.Count);
        }

    }
}
