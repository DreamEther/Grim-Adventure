using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] int energyLevel = 3;
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

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        
        //PlayerMovement();
        //runAnim.Play("NinjaSwordRunning");
    }

    public void UpdateLane(LanePosition lane)
    {
        CurrentPosition = lane;
    }

    public LanePosition GetCurrentLane()
    {
        return this.currentPosition;
    }
    public void ExpendOneEnergyOnAttack()
    {
        energyLevel--;
    }




}
