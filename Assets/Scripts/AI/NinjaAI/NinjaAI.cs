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

    //[SerializeField] public static List<AttackSequence> attackSequenceInventory;
    [HideInInspector] private Animator ninjaAnim;
    [SerializeField] public float accuracy = 4f;
    private float speedFactor;
    HitAnim hitAnim;
    private Vector2 _cachedStartingPos;
    private Vector2 myPosVectorTwo;
    // Start is called before the first frame update
    private Vector2 currentPos;
    [SerializeField] public AttackSequence _myDefaultAttackSequence;
    [SerializeField] public BaseMinion _myDefaultMinion;
    [SerializeField] public int inventorySpace;
    private NinjaRushUI ninjaRushUI;
    public GameEvents getEnemiesInScene;
    public bool rushSelected;
    private Vector3 _hoverPosition;
    public PlayerGrid _playerGrids;
    [SerializeField] MoveButtonTrigger _moveButtonTrigger;
    private SelectLane[] _listOfPlayerLanes;
    [SerializeField] public Vector3 offsetWhenMoving;
    void Awake()
    {        
        if (ninjaAnim == null)
        {
            ninjaAnim = gameObject.GetComponent<Animator>();
        }  
    }   

    void Start()
    {
        _playerGrids.Clicked += MovePosition;
        offsetWhenMoving = new Vector3(0, 2, 0);
        _listOfPlayerLanes = gameObject.GetComponents<SelectLane>();
        _hoverPosition = new Vector3();
       // isMyTurn = true; //NEED TO REMOVE!!
        ninjaRushUI = gameObject.GetComponentInChildren<NinjaRushUI>();
        myAttackSequences = new List<AttackSequence>();
        _cachedStartingPos = new Vector2();
        _cachedStartingPos = transform.position;
        hitAnim = FindObjectOfType<HitAnim>();
        AddDefaultAttackSequence();
        AddDefaultMinion();
        if (SceneLoader.CurrentSceneIndex > 0)
        {
            distanceToNearestGameObject = transform.position - newNearestGameObject.transform.position;
        }
        //adding event listener to every SelectLane OnPointerDownEvent. 
        foreach (SelectLane lane in _listOfPlayerLanes)
        {
            lane.MoveClicked += MovePosition;
            Debug.Log("lane in list of lanes: " + lane);
        }
    }

    private void Update()
    {
        if (!isMyTurn)
        {
            UIController.combatLog.SetActive(false);
        }
        GetDistanceToNearestGameObject();
        ReadyNinjaRushUI();
    }

    private void GetDistanceToNearestGameObject()
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
    private void ReadyNinjaRushUI()
    {
        if (isMyTurn)
        {
            UIController.combatLog.SetActive(true);
            if (rushSelected)
            {
                UIController.ninjaRushUI.SetActive(true);
            }
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
            }
        }
        
    }
 
    public void MoveSelected()
    {
        moveSelected = true;
    }

    public void OpenRushMenuOnClick()
    {
        rushSelected = true;
    }
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
    public void AddAttackSequenceToInventory(AttackSequence attackSequence)
    {  
        myAttackSequences.Add(attackSequence);
        if (OnSequenceAdded != null)
        {
            OnSequenceAdded.Invoke();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "enemy")
        {
            energyLevel--;
        }
    }
    public void EndAttack()
    {
        if(energyLevel == 0)
        {
            myPosVectorTwo = new Vector2(transform.position.x, transform.position.y);
            Vector2 backToStartPos = new Vector2();
            backToStartPos = _cachedStartingPos - myPosVectorTwo;
            ninjaAnim.StopPlayback();
            transform.position = Vector2.MoveTowards(transform.position, _cachedStartingPos, speed * Time.deltaTime);

            if(backToStartPos.magnitude < accuracy)
            {
                isMyTurn = false;
            }
        }
    }
    public override void TriggerRunAnim()
    {
        Vector3 XOffset = new Vector3(3f, 0, 0);

        if (ninjaAnim != null && ninjaAnim.isActiveAndEnabled) // gets rid of unassignedReferenceException error
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



