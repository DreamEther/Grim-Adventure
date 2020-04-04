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
    [HideInInspector] private int damage;
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

    void Awake()
{
     if (ninjaAnim == null)
        {
            ninjaAnim = gameObject.GetComponent<Animator>();
        }
        // if(nearestGameObject == null)
        // {
        //     GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);
        // }
         
}

    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        //    RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
        //    Vector2 rayHitConvert = new Vector2(rayHit.transform.position.x, rayHit.transform.position.y);
        //    transform.position = Vector2.MoveTowards(transform.position, rayHitConvert, speed * Time.deltaTime);

        //}
    }
    void Start()
    {
         myAttackSequences = new List<AttackSequence>();
        _cachedStartingPos = new Vector2();
        _cachedStartingPos = transform.position;
        hitAnim = FindObjectOfType<HitAnim>();
        if(myAttackSequences.Count == 0)
        {
            AddAttackSequenceToInventory(_myDefaultAttackSequence);
            if (OnSequenceAdded != null)
            {
                OnSequenceAdded.Invoke();
            }
        }

        if (myMinions.Count == 0)
        {
            AddMinionToInventory(_myDefaultMinion);
            if (OnMinionAdded != null)
            {
                OnMinionAdded.Invoke();
            }
        }

        //  distanceToNearestGameObject = new Vector3();
        //GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);

        // newNearestGameObject = new GameObject();
        //if (SceneLoader.CurrentSceneIndex > 0)
        //{
        //    distanceToNearestGameObject = transform.position - newNearestGameObject.transform.position;
        //}
        // attackSequenceButtons = UIController.combatLog.GetComponentsInChildren<Button>();
    } 

    public void AddMinionToInventory(BaseMinion minion)
    {
        if (myAttackSequences.Count <= inventorySpace)
        {
            myMinions.Add(minion);
        }
    }

    public void RemoveMinionToInventory(BaseMinion minion)
    {
        myMinions.Remove(minion);
    }
    public void AddAttackSequenceToInventory(AttackSequence attackSequence)
    {  
            myAttackSequences.Add(attackSequence);
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
            //float distance = distanceToNearestGameObject.magnitude;
            //speedFactor = (100f / distance);
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



