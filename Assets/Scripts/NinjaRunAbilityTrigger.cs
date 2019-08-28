using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaRunAbilityTrigger : MonoBehaviour
{
   // public static bool beginMoving = false;
    [HideInInspector] public float speed = 6f;
    Animator anim;
    NinjaSlashAbilityTrigger ninjaSlashAbilityTrigger;
    // Start is called before the first frame update
    void Start()
    {
        ninjaSlashAbilityTrigger = GetComponent<NinjaSlashAbilityTrigger>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerRunAnim()
    {
        //beginMoving = true;
        if (anim != null && anim.isActiveAndEnabled) // gets rid of unassignedReferenceException error
        {
            anim.SetBool("BeginLaneCharge", true);
            transform.position = Vector3.MoveTowards(transform.position, ninjaSlashAbilityTrigger.nearestGameObject.transform.position, speed * Time.deltaTime);
        }
    }
    }

   
