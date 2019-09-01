using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterLane2 : MonoBehaviour
{
    public static List<GameObject> enemiesInLaneTwo;

    void Start()
    {
        enemiesInLaneTwo = new List<GameObject>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            enemiesInLaneTwo.Add(other.gameObject);
            Debug.Log(enemiesInLaneTwo.Count);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            enemiesInLaneTwo.Remove(other.gameObject);
            Debug.Log(enemiesInLaneTwo.Count);
        }

    }
}
