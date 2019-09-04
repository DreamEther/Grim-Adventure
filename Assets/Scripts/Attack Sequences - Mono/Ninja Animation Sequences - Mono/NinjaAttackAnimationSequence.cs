using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NinjaAttackAnimationSequence : MonoBehaviour
{
    [HideInInspector] private int damage;
    [HideInInspector] private Animator ninjaAnim;
    [HideInInspector] public float accuracy = 4f;
    [SerializeField] int speed;
    public GameObject nearestGameObject;
    private List<GameObject> enemies;
    private Vector3 distanceToNearestGameObject;
    private List<GameObject> laneOneSpawnPoints;

    [SerializeField] bool playHitAnim = false;
    HitAnim hitAnim;
    // Start is called before the first frame update

GameObject newNearestGameObject;

    void Start()
    {
        hitAnim = FindObjectOfType<HitAnim>();
        Debug.Log(hitAnim);
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemy"));
        GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);
        newNearestGameObject =  GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);
        laneOneSpawnPoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Lane1"));
    }



    // Update is called once per frame

    void Update()
    {       
        if (laneOneSpawnPoints == null)
        {
            laneOneSpawnPoints = new List<GameObject>(GameObject.FindGameObjectsWithTag("Lane1"));
        }

        if (ninjaAnim == null)
        {
            ninjaAnim = gameObject.GetComponent<Animator>();
        }
    }

    public void TriggerRunAnim()
    {
        Vector3 XOffset = new Vector3(3f, 0, 0);
        //beginMoving = true;
        if (ninjaAnim != null && ninjaAnim.isActiveAndEnabled) // gets rid of unassignedReferenceException error
        {

            if (gameObject.transform.position != newNearestGameObject.transform.position - XOffset)
            {
                ninjaAnim.SetBool("PlayRunAnim", true);
                transform.position = Vector3.MoveTowards(transform.position, newNearestGameObject.transform.position - XOffset, speed * Time.deltaTime);
            }
            else
            {
                ninjaAnim.SetBool("PlayRunAnim", false);
            }
        }

    }

 /* public IEnumerator TriggerRunAnim()
{
    Vector3 XOffset = new Vector3(3f, 0, 0);
    while (!Mathf.Approximately((transform.position - newNearestGameObject.transform.position - XOffset).sqrMagnitude, 0))
    {
        transform.position = Vector3.MoveTowards(transform.position, newNearestGameObject.transform.position - XOffset, speed * Time.deltaTime);
        yield return null;
    }
}*/
 
    public void TriggerNinjaAttackSequence() // being called in the stateController Update function 
    {
        GetMagnitudeOfNearestEnemy();
        SwitchBetweenRunandAttackAnim();
        TriggerRunAnim(); // the order of trigger run matters since we need to know what the next nearestGameObjects position is after we kill the inital closest enemy
    }

    private void GetMagnitudeOfNearestEnemy()
    {
        if (newNearestGameObject != null) // this is so I can keep track of the Vector Length when I refer to 'distanceToNearestGameObject.magnitude
        {
            ninjaAnim.SetBool("triggerRunFromAttack", true); // need this so that our char transitions back into his run from any state. 
            distanceToNearestGameObject = newNearestGameObject.transform.position - transform.position;          
        }
    }

    private void SwitchBetweenRunandAttackAnim()
    {
        if (newNearestGameObject == null) // this is to find the next nearest enemy once the previous nearest enemy is killed 
        {
            newNearestGameObject = GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);
            Debug.Log(distanceToNearestGameObject.magnitude);
        }

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

            foreach (GameObject enemy in OnTriggerEnterLane1.enemiesInLaneOne)
            {
                   var distance = Vector3.Distance(transform.position, enemy.transform.position);

                    if (distance < smallestDistance)
                    {
                        smallestDistance = distance;

                        newNearestGameObject = enemy;
                        Debug.Log(newNearestGameObject.gameObject.name);
                    }
            }    
        return newNearestGameObject;
    }     

    public void PlayStabAnim()
    {

    }
}



