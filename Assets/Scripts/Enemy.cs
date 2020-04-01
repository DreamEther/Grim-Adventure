using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public GameObject player;

    public int _currentLane;
    public int health;
    public int attackPower;
    public int energyLevel;
    public string name;
    public bool isMyTurn = false;
    private PlayerController playerChar;

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //       playerChar = other.gameObject.GetComponent<PlayerController>();     
    //       playerChar.energyLevel--;
    //}
    public int GetCurrentLane()
    {
        return _currentLane;
    }

    public void SetCurrentLane(int currentLane)
    {
        _currentLane = currentLane;
    }



    public GameObject GetPlayer()
    {
        return player;
    }

}
