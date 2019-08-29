using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NinjaSlashAnimationTrigger : MonoBehaviour
{
    [HideInInspector] private int damage;
    [HideInInspector] private Animator ninjaAnim;
    [HideInInspector] private float accuracy = 4f;
    public GameObject nearestGameObject;
    private List<GameObject> enemies;
    private Vector3 distanceToNearestGameObject;
    bool triggerRunFromSlash;
    // Start is called before the first frame update


    void Start()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemy"));
        GetNearestGameObject(enemies);
        distanceToNearestGameObject = nearestGameObject.transform.position - transform.position;
        
      
        //ninjaAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ninjaAnim == null)
        {
            ninjaAnim = gameObject.GetComponent<Animator>();
        }
        //TriggerSlashAnim();
    }

    public void TriggerSlashAnim() // being called in the stateController Update function 
    {
        if (nearestGameObject != null) // this is so I can keep track of the Vector Length when I refer to 'distanceToNearestGameObject.magnitude
        {
            ninjaAnim.SetBool("triggerRunFromSlash", false);
            distanceToNearestGameObject = nearestGameObject.transform.position - transform.position;
        }
        Debug.Log(distanceToNearestGameObject.magnitude);

        SwitchBetweenRunandAttackAnim();

        //Vector3 myPos = new Vector3(transform.position.x, 0, 0);
        //ninjaAnim.SetBool("StartSlash", true);             
    }

    private void SwitchBetweenRunandAttackAnim()
    {
        if (nearestGameObject == null) // this is to find the next nearest enemy once the previous nearest enemy is killed 
        {
            ninjaAnim.SetBool("triggerRunFromSlash", true);
            ninjaAnim.SetBool("PlayRunAnim", true);
            enemies.Clear(); // clearing my list of enemies
            enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemy")); // updating the list on each PLAYERTURN state to account for new enemies being instantiated by enemy ai. also accounts for enemies killed
            GetNearestGameObject(enemies);
        }
        else if (distanceToNearestGameObject.magnitude < accuracy)
        {
            ninjaAnim.SetBool("PlayRunAnim", false);
            StartCoroutine(PlayOneSlash("StartSlash"));
            ninjaAnim.SetBool("PlayStabAnim", true);
        }
    }

    public void TriggerRunFromSlash()
    {
        triggerRunFromSlash = true;
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
       
        foreach (var enemy in enemies)
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
}
