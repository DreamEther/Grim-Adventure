using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NinjaSlashAbilityTrigger : MonoBehaviour
{
    [HideInInspector] private int damage = 5;
    [HideInInspector] private Animator ninjaAnim;
    [HideInInspector] private float accuracy = 0.15f;
    public GameObject nearestGameObject;
    List<GameObject> enemies;
    Vector3 distanceToNearestGameObject;
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
        ninjaAnim = gameObject.GetComponent<Animator>();
        //TriggerSlashAnim();
    }

    public void TriggerSlashAnim()
    {
        if (nearestGameObject == null)
        {
            GetNearestGameObject(enemies);
        }
        else if (distanceToNearestGameObject.magnitude > accuracy)
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
                    //if (nearestGameObject.gameObject == null)
                    //{
                    //    GetNearestGameObject(enemies);
                    //}
                
            }
        }

        return nearestGameObject;
    }
}
