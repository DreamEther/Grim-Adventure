using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    [SerializeField] public int energyLevel = 3;
    [SerializeField] public int speed;
    public bool isMyTurn = false;

    public enum LanePosition
    {
        NULL = 0, 
        LANE1,
        LANE2,
        LANE3
    };

    private LanePosition currentPosition; 

    public LanePosition CurrentPosition{get; set;}

    public virtual void UpdateLane(LanePosition lane)
    {
        CurrentPosition = lane;
    }

    public virtual LanePosition GetCurrentLane()
    {
        return this.currentPosition;
    }





}
