using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NinjaAI : PlayerController
{
    public delegate void SequenceAdded();
    public SequenceAdded OnSequenceAdded;

    public delegate void MinionAdded();
    public event MinionAdded OnMinionAdded;

    [SerializeField] public float accuracy = 4f;
    [SerializeField] public Vector3 offsetWhenMoving; // need this offset to better align character with the center of the lane that they're moving to
    private Animator ninjaAnim;
    private HitAnim hitAnim;
    private Vector3 _cachedStartingPos; // trying to use this to move back to starting position when energy level reaches zero
    private Vector2 myPosVectorTwo; // trying to use this to move back to starting position when energy level reaches zero
    Vector2 backToStartPos;
   
    public bool rushSelected;
    private Vector3 _hoverPosition;
 
    void Awake()
    {        
        if (ninjaAnim == null)
        {
            ninjaAnim = gameObject.GetComponent<Animator>();
        }  
    }   

    void Start()
    {
        backToStartPos = new Vector2();
        _playerGrids.Clicked += MovePosition;
        offsetWhenMoving = new Vector3(0, 2, 0);
        _hoverPosition = new Vector3();
       // isMyTurn = true; //NEED TO REMOVE!!
        myAttackSequences = new List<AttackSequence>();
        _cachedStartingPos = new Vector3();
        _cachedStartingPos = transform.position;
        Debug.Log("starting pos: " + _cachedStartingPos);
        hitAnim = FindObjectOfType<HitAnim>();
        AddDefaultAttackSequence();
        AddDefaultMinion();
        //if (SceneLoader.CurrentSceneIndex > 0)
        //{
        //    distanceToNearestGameObject = transform.position - newNearestGameObject.transform.position;
        //}
    }

    private void Update()
    {

        if (isMyTurn)
        {
            myTurnCircle.GetComponent<SpriteRenderer>().enabled = true;
            GetDistanceToNearestGameObject();
            ReadyNinjaRushUI();
        }
        else
        {
            myTurnCircle.GetComponent<SpriteRenderer>().enabled = false;
        }

    }

    private void ReadyNinjaRushUI()
    {
            UIController.combatLog.SetActive(true);
            if (_openRushUI.placeRushButtonClicked)
            {
                UIController.ninjaRushUI.SetActive(true);
                _openRushUI.placeRushButtonClicked = false;
            }      
    }

    public void MovePosition()
    {
        if (isMyTurn)
        {
            if (_moveButtonTrigger.moveButtonClicked == true)
            {
                Debug.Log("moving");
                _hoverPosition = _playerGrids.GetCurrentOnHoverPosition();
                transform.position = _hoverPosition + offsetWhenMoving;
                _moveButtonTrigger.moveButtonClicked = false;
            }
        }
        
    }

    //public void OpenRushMenuOnClick()
    //{
    //    rushSelected = true;
    //}
    private void AddDefaultMinion()
    {
        if (myMinions.Count == 0)
        {
            AddMinionToInventory(_myDefaultMinion);
            if (OnMinionAdded != null)
            {
                OnMinionAdded.Invoke();
            }
        }
    }

    private void AddDefaultAttackSequence()
    {
        if (myAttackSequences.Count == 0)
        {
            AddAttackSequenceToInventory(_myDefaultAttackSequence);
            if (OnSequenceAdded != null)
            {
                OnSequenceAdded.Invoke();
            }
        }
    }

    public void AddAttackSequenceToInventory(AttackSequence attackSequence)
    {
        myAttackSequences.Add(attackSequence);
        if (OnSequenceAdded != null)
        {
            OnSequenceAdded.Invoke();
        }
    }

    public void AddMinionToInventory(BaseMinion minion)
    {
        if (myAttackSequences.Count <= inventorySpace)
        {
            myMinions.Add(minion);
        }
    }

    public void RemoveMinionFromInventory(BaseMinion minion)
    {
        myMinions.Remove(minion);
    }
 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            energyLevel--;
        }
    }

    //this function is called by another function which institutes a delay before executing this method. 
    public override void EndAttack()
    {
        if (energyLevel == 0)
        {
            isMyTurn = false;
            Vector3 changeAxis = new Vector3(0, 180, 0);
            ninjaAnim.SetBool("PlayIdleAnim", true);
            ninjaAnim.SetBool("PlayRunAnim", false);
            transform.position += (_cachedStartingPos - transform.position) * speed * Time.deltaTime;
            //transform.position = Vector3.MoveTowards(transform.position, _cachedStartingPos, speed * Time.deltaTime);

            if (backToStartPos.magnitude < accuracy)
            {
                isMyTurn = false;
            }
        }
    }

    public override void TriggerRunAnim()
    {
        Vector3 XOffset = new Vector3(3f, 0, 0);

        if (ninjaAnim != null && ninjaAnim.isActiveAndEnabled && isMyTurn) // gets rid of unassignedReferenceException error
        {
            if (transform.position != newNearestGameObject.transform.position - XOffset)
            {
                ninjaAnim.SetBool("PlayRunAnim", true);
                transform.position = Vector2.MoveTowards(transform.position, newNearestGameObject.transform.position - XOffset, Time.deltaTime * speed);         
            }
            else
            {
                ninjaAnim.SetBool("PlayRunAnim", false);
            }
        }
    }

 //passing delegate here to make the attack sequence dynamic
    public void TriggerNinjaAttackSequence(Attack attack) // being called in the stateController Update function 
    {
        GetMagnitudeOfNearestEnemy();
        TriggerRunAnim(); 
        attack();
        // the order of trigger run matters since we need to know what the next nearestGameObjects position is after we kill the inital closest enemy
    }
    public override void GetMagnitudeOfNearestEnemy()
    {      
            ninjaAnim.SetBool("triggerRunFromAttack", true); // need this so that our char transitions back into his run from any state. 
            distanceToNearestGameObject = newNearestGameObject.transform.position - transform.position;
    }

    public void AttackSequence1()
    {
        if (distanceToNearestGameObject.magnitude < accuracy)
        {    
            ninjaAnim.SetBool("PlayRunAnim", false);
            ninjaAnim.SetBool("triggerRunFromAttack", false);
            StartCoroutine(PlayOneSlash("StartSlash"));
            ninjaAnim.SetBool("PlayStabAnim", true);
        }
    }

    public void AttackSequence2()
    {
        if (distanceToNearestGameObject.magnitude < accuracy)
        {
            ninjaAnim.SetBool("PlayRunAnim", true);
           
        }
    }
    public override void PlayHitBoxAnim() // referencing this directly on the animations themselves. 
    {
        hitAnim.SetPosition(newNearestGameObject.transform.position);
        hitAnim.PlayAnim();
    }
    public IEnumerator PlayOneSlash(string paramName)
    {
        ninjaAnim.SetBool(paramName, true);
        yield return null;
        ninjaAnim.SetBool(paramName, false);
    }    
}



