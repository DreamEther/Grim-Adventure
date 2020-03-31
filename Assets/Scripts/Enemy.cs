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
