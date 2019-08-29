using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NinjaSlashAbilityTrigger : MonoBehaviour
{
    [HideInInspector] private int damage = 5;
    [HideInInspector] private Animator ninjaAnim;
    [HideInInspector] private float accuracy = .5f;
    public GameObject nearestGameObject;
    private List<GameObject> enemies;
    private Vector3 distanceToNearestGameObject;
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
            distanceToNearestGameObject = nearestGameObject.transform.position - transform.position;
        }
        Debug.Log(distanceToNearestGameObject.magnitude);

        if (nearestGameObject == null) // this is to find the next nearest enemy once the previous nearest enemy is killed 
        {
            enemies.Clear(); // clearing my list of enemies
            enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("enemy")); // updating the list on each PLAYERTURN state to account for new enemies being instantiated by enemy ai. also accounts for enemies killed
            GetNearestGameObject(enemies);
        }
        else if (distanceToNearestGameObject.magnitude < accuracy)  
        {           
            ninjaAnim.SetBool("StartSlash", true);
        }
        //Vector3 myPos = new Vector3(transform.position.x, 0, 0);
        //ninjaAnim.SetBool("StartSlash", true);             
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
