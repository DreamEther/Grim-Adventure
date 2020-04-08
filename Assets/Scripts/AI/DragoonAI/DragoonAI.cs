using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragoonAI : PlayerController
{
    public delegate void SequenceAdded();
    public SequenceAdded OnSequenceAdded;

    public delegate void MinionAdded();
    public event MinionAdded OnMinionAdded;

    [HideInInspector] private Animator dragoonAnim;
    [SerializeField] public float accuracy = 4f;
    private HitAnim hitAnim;
    private Vector2 _cachedStartingPos; // trying to use this to move back to starting position when energy level reaches zero
    private Vector2 myPosVectorTwo; // trying to use this to move back to starting position when energy level reaches zero
    // Start is called before the first frame update
    private Vector2 currentPos;
    private DragoonRushUI dragoonRushUI;
    private bool rushSelected;
    private Vector3 offsetWhenMoving;
    private Vector3 _hoverPosition;
    void Awake()
    {
        if (dragoonAnim == null)
        {
            dragoonAnim = gameObject.GetComponent<Animator>();
        }

    }
    void Start()
    {
        _playerGrids.Clicked += MovePosition;
        myAttackSequences = new List<AttackSequence>();
        offsetWhenMoving = new Vector3(0, 2, 0);
        _hoverPosition = new Vector3();
        AddDefaultAttackSequence();
        _cachedStartingPos = new Vector2();
        _cachedStartingPos = transform.position;
        hitAnim = FindObjectOfType<HitAnim>();
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
            ReadyDragoonRushUI();
        }
        else
        {
            myTurnCircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void ReadyDragoonRushUI()
    {
            UIController.combatLog.SetActive(true);
            if (_openRushUI.placeRushButtonClicked)
            {
                UIController.dragoonRushUI.SetActive(true);
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

    public override void TriggerRunAnim()
    {
        Vector3 Offset = new Vector3(3f, -1f, 0);

        if (dragoonAnim != null && dragoonAnim.isActiveAndEnabled) // gets rid of unassignedReferenceException error
        {
            if (transform.position != newNearestGameObject.transform.position - Offset)
            {
                dragoonAnim.SetBool("PlayRunAnim", true);
                transform.position = Vector2.MoveTowards(transform.position, newNearestGameObject.transform.position - Offset, Time.deltaTime * speed);
            }
            else
            {
                dragoonAnim.SetBool("PlayRunAnim", false);
            }
        }
    }

    //passing delegate here to make the attack sequence dynamic
    public void TriggerDragoonAttackSequence(Attack attack) // being called in the stateController Update function 
    {
        GetMagnitudeOfNearestEnemy();
        TriggerRunAnim();
        attack();
        // the order of trigger run matters since we need to know what the next nearestGameObjects position is after we kill the inital closest enemy
    }
    public override void GetMagnitudeOfNearestEnemy()
    {
        dragoonAnim.SetBool("TriggerRunFromAttack", true); // need this so that our char transitions back into his run from any state. 
        distanceToNearestGameObject = newNearestGameObject.transform.position - transform.position;
        //float distance = distanceToNearestGameObject.magnitude;
        //speedFactor = (100f / distance);
    }
    public void AttackSequence1()
    {
        if (distanceToNearestGameObject.magnitude < accuracy)
        {
            dragoonAnim.SetBool("PlayRunAnim", false);
            dragoonAnim.SetBool("triggerRunFromAttack", false);
            dragoonAnim.SetBool("TriggerAttackSequence1", true);
        }
    }


    public override void PlayHitBoxAnim() // referencing this directly on the animations themselves. 
    {
        hitAnim.SetPosition(newNearestGameObject.transform.position);
        hitAnim.PlayAnim();
    }

    public override void EndAttack()
    {
        throw new NotImplementedException();
    }

 


    //public IEnumerator TransitionToOtherAnim(string paramName)
    //{
    //    dragoonAnim.SetBool(paramName, true);
    //    yield return null;
    //    dragoonAnim.SetBool(paramName, false);
    //}
}
