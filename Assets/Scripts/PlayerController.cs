﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerController : MonoBehaviour
{
    public delegate void Attack();

    [SerializeField] public GameObject myTurnCircle;
    [SerializeField] public int inventorySpace;
    [SerializeField] public MoveButtonTrigger _moveButtonTrigger;
    [SerializeField] public RushButtonTrigger _openRushUI;

    [SerializeField] public AttackSequence _myDefaultAttackSequence;
    [SerializeField] public BaseMinion _myDefaultMinion;
    [SerializeField] public GameEvents getEnemiesInScene;
    [SerializeField] public PlayerGrid _playerGrids; //need this to get a reference to combat log parent object. This is set in the inspector
    public Vector3 distanceToNearestGameObject;
    [SerializeField] public int energyLevel = 3;
    [SerializeField] public int speed;
    public bool isMyTurn = false;
    public GameObject newNearestGameObject;
    private LanePosition currentPosition;
    public List<AttackSequence> myAttackSequences;
    public List<BaseMinion> myMinions;
    public bool moveSelected;
    [SerializeField] public float delayOnAttackEnd = 1f;

   

    public LanePosition CurrentPosition { get; set; }

    public enum LanePosition
    {
        NULL = 0,
        LANE1,
        LANE2,
        LANE3
    };

    public virtual IEnumerator Wait(float seconds, Action action)
    {
        yield return new WaitForSeconds(10);
    }
    public abstract void EndAttack();

    public virtual void CallEndAttack()
    {
        Invoke("EndAttack", delayOnAttackEnd);
    }
    public abstract void PlayHitBoxAnim();

    public abstract void GetMagnitudeOfNearestEnemy();

    public abstract void TriggerRunAnim();
    public virtual void UpdateLane(LanePosition lane)
    {
        CurrentPosition = lane;
    }

    public virtual LanePosition GetCurrentLane()
    {
        return this.currentPosition;
    }

    public virtual GameObject GetNearestGameObject(List<GameObject> enemies)
    {
        float smallestDistance = Mathf.Infinity;
        if (OnTriggerEnterLane1.enemiesInLaneOne != null)
        {
            if (CurrentPosition == LanePosition.LANE1)
            {
                foreach (GameObject enemy in enemies)
                {
                    var distance = Vector3.Distance(transform.position, enemy.transform.position);

                    if (distance < smallestDistance)
                    {
                        smallestDistance = distance;
                        newNearestGameObject = enemy;
                        Debug.Log("Nearest Enemy: " + newNearestGameObject.gameObject.name);
                    }
                }
            }
            else if (CurrentPosition == LanePosition.LANE2)
            {
                foreach (GameObject enemy in enemies)
                {
                    var distance = Vector3.Distance(transform.position, enemy.transform.position);

                    if (distance < smallestDistance)
                    {
                        smallestDistance = distance;
                        newNearestGameObject = enemy;
                        Debug.Log("Nearest Enemy: " + newNearestGameObject.gameObject.name);
                    }
                }
            }
        }
        return newNearestGameObject;
    }
    public virtual void GetDistanceToNearestGameObject()
    {
        if (newNearestGameObject == null) // this is to find the next nearest enemy once the previous nearest enemy is killed 
        {
            //need to pass in to GetNearestGameObject the correct Lane depending on what lane this object is in
            if (CurrentPosition == LanePosition.LANE1)
            {
                newNearestGameObject = GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);
                if (distanceToNearestGameObject == null)
                {
                    distanceToNearestGameObject = newNearestGameObject.transform.position - transform.position;
                }
            }
            else if (CurrentPosition == LanePosition.LANE2)
            {
                newNearestGameObject = GetNearestGameObject(OnTriggerEnterLane2.enemiesInLaneTwo);
                if (distanceToNearestGameObject == null)
                {
                    distanceToNearestGameObject = newNearestGameObject.transform.position - transform.position;
                }
            }
            return;
        }
    }
}




