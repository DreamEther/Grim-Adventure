using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragoonAI : PlayerController
{
    public delegate void SequenceAdded();
    public event SequenceAdded OnSequenceAdded;

    [SerializeField] public static List<AttackSequence> attackSequenceInventory;
    [HideInInspector] private int damage;
    [HideInInspector] private Animator dragoonAnim;
    [SerializeField] public float accuracy = 4f;
    private float speedFactor;
    private HitAnim hitAnim;
    private Vector2 _cachedStartingPos;
    private Vector2 myPosVectorTwo;
    // Start is called before the first frame update
    private Vector2 currentPos;
    void Awake()
    {
        if (dragoonAnim == null)
        {
            dragoonAnim = gameObject.GetComponent<Animator>();
        }

    }
    void Start()
    {

        _cachedStartingPos = new Vector2();
        _cachedStartingPos = transform.position;
        hitAnim = FindObjectOfType<HitAnim>();
    }

    public override void TriggerRunAnim()
    {
        Vector3 XOffset = new Vector3(3f, 0, 0);

        if (dragoonAnim != null && dragoonAnim.isActiveAndEnabled) // gets rid of unassignedReferenceException error
        {
            if (transform.position != newNearestGameObject.transform.position - XOffset)
            {
                dragoonAnim.SetBool("PlayRunAnim", true);
                transform.position = Vector2.MoveTowards(transform.position, newNearestGameObject.transform.position - XOffset, Time.deltaTime * speed);
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
        dragoonAnim.SetBool("triggerRunFromAttack", true); // need this so that our char transitions back into his run from any state. 
        distanceToNearestGameObject = newNearestGameObject.transform.position - transform.position;
        //float distance = distanceToNearestGameObject.magnitude;
        //speedFactor = (100f / distance);
    }
    public void AttackSequence1()
    {
        if (distanceToNearestGameObject.magnitude < accuracy)
        {
            dragoonAnim.SetBool("PlayRunAnim", false);
            dragoonAnim.SetBool("TriggerRunFromAttack", false);
            dragoonAnim.SetBool("DownwardSlash", true);
        }
    }
    public override void PlayHitBoxAnim() // referencing this directly on the animations themselves. 
    {
        hitAnim.SetPosition(newNearestGameObject.transform.position);
        hitAnim.PlayAnim();
    }


    //public IEnumerator TransitionToOtherAnim(string paramName)
    //{
    //    dragoonAnim.SetBool(paramName, true);
    //    yield return null;
    //    dragoonAnim.SetBool(paramName, false);
    //}
}
