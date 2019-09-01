using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NinjaAttackAnimationSequence : MonoBehaviour
{
    [HideInInspector] private int damage;
    [HideInInspector] private Animator ninjaAnim;
    [HideInInspector] private float accuracy = 4f;
    [SerializeField] int speed;
    public GameObject nearestGameObject;
    private List<GameObject> enemies;
    private Vector3 distanceToNearestGameObject;
    private List<GameObject> laneOneSpawnPoints;
    // Start is called before the first frame update


    void Start()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemy"));
        GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);
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
        //TriggerSlashAnim();
    }

    public void TriggerRunAnim()
    {
        Vector3 XOffset = new Vector3(3f, 0, 0);
        //beginMoving = true;
        if (ninjaAnim != null && ninjaAnim.isActiveAndEnabled) // gets rid of unassignedReferenceException error
        {

            if (gameObject.transform.position != nearestGameObject.transform.position - XOffset)
            {
                ninjaAnim.SetBool("PlayRunAnim", true);
                transform.position = Vector3.MoveTowards(transform.position, nearestGameObject.transform.position - XOffset, speed * Time.deltaTime);
            }
            else
            {
                ninjaAnim.SetBool("PlayRunAnim", false);
            }
        }

    }

    public void TriggerNinjaAttackSequence() // being called in the stateController Update function 
    {

        if (nearestGameObject != null) // this is so I can keep track of the Vector Length when I refer to 'distanceToNearestGameObject.magnitude
        {
            ninjaAnim.SetBool("triggerRunFromSlash", false);
            distanceToNearestGameObject = nearestGameObject.transform.position - transform.position;
        }

      //  Debug.Log(distanceToNearestGameObject.magnitude);

        SwitchBetweenRunandAttackAnim();
        TriggerRunAnim(); // the order of trigger run matters since we need to know what the next nearestGameObjects position is after we kill the inital closest enemy
    }

    private void SwitchBetweenRunandAttackAnim()
    {
        if (nearestGameObject == null) // this is to find the next nearest enemy once the previous nearest enemy is killed 
        {
            ninjaAnim.SetBool("triggerRunFromSlash", true);
            ninjaAnim.SetBool("PlayRunAnim", true);
            enemies.Clear(); // clearing my list of enemies
            enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemy")); // updating the list on each PLAYERTURN state to account for new enemies being instantiated by enemy ai. also accounts for enemies killed
            GetNearestGameObject(OnTriggerEnterLane1.enemiesInLaneOne);
        }

        else if (distanceToNearestGameObject.magnitude < accuracy)
        {
            ninjaAnim.SetBool("PlayRunAnim", false);
            StartCoroutine(PlayOneSlash("StartSlash"));
            ninjaAnim.SetBool("PlayStabAnim", true);
        }

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

                        nearestGameObject = enemy;
                    }
            }    
        return nearestGameObject;
    }     

    public void PlayStabAnim()
    {

    }
}



