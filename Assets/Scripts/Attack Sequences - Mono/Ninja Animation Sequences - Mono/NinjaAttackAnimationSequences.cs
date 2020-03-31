using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class NinjaAttackAnimationSequences : MonoBehaviour
{
    public delegate void Attack();
    [HideInInspector] private int damage;
    [HideInInspector] private Animator ninjaAnim;
    [HideInInspector] public float accuracy = 4f;
    [SerializeField] int speed;
    private float speedFactor;
    private Vector3 distanceToNearestGameObject;
    HitAnim hitAnim;
    private PlayerController player;
    
    // Start is called before the first frame update
    private Vector3 currentPos;
    private GameObject newNearestGameObject;

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
    void Start()
    {

        player = gameObject.GetComponent<PlayerController>();
        hitAnim = FindObjectOfType<HitAnim>();

        GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);
        newNearestGameObject =  GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);
        if (SceneLoader.CurrentSceneIndex > 0)
        {
            distanceToNearestGameObject = transform.position - newNearestGameObject.transform.position;
        }
    }



    // Update is called once per frame

    void Update()
    {
      
        if (newNearestGameObject == null) // this is to find the next nearest enemy once the previous nearest enemy is killed 
        {
            newNearestGameObject = GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);
            if (distanceToNearestGameObject == null)
            {
                distanceToNearestGameObject = newNearestGameObject.transform.position - transform.position;
            }
            //newNearestGameObject = GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);
            // Debug.Log("This is the magnitude of the distance between me and nearest enemy: " + distanceToNearestGameObject.magnitude);
        }
      

        // if (ninjaAnim == null)
        // {
        //     ninjaAnim = gameObject.GetComponent<Animator>();
        // }
    }

    public void TriggerRunAnim()
    {
        Vector3 XOffset = new Vector3(3f, 0, 0);
        Vector3 normalized = (newNearestGameObject.transform.position - XOffset).normalized;
        //beginMoving = true;
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
    private void GetMagnitudeOfNearestEnemy()
    {      
            ninjaAnim.SetBool("triggerRunFromAttack", true); // need this so that our char transitions back into his run from any state. 
            distanceToNearestGameObject = newNearestGameObject.transform.position - transform.position;
            //float distance = distanceToNearestGameObject.magnitude;
            //speedFactor = (100f / distance);
    }

    public void TriggerAttackSequence1()
    {
        if (distanceToNearestGameObject.magnitude < accuracy)
        {    
            ninjaAnim.SetBool("PlayRunAnim", false);
            ninjaAnim.SetBool("triggerRunFromAttack", false);
            StartCoroutine(PlayOneSlash("StartSlash"));
            ninjaAnim.SetBool("PlayStabAnim", true);
        }
    }
public void PlayHitBoxAnim() // referencing this directly on the animations themselves. 
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

    private GameObject GetNearestGameObject(List<GameObject> enemies)
    {
        float smallestDistance = Mathf.Infinity;
         if(OnTriggerEnterLane1.enemiesInLaneOne != null)
         {
            foreach (GameObject enemy in OnTriggerEnterLane1.enemiesInLaneOne)
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
        return newNearestGameObject;
    }     

    public void PlayStabAnim()
    {

    }
}



