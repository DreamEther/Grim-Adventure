using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaRunAnimationTrigger : MonoBehaviour
{
   // public static bool beginMoving = false;
    [HideInInspector] public float speed = 6f;
    Animator anim;
    NinjaSlashAnimationTrigger ninjaSlashAbilityTrigger;
    // Start is called before the first frame update
    void Start()
    {
        ninjaSlashAbilityTrigger = GetComponent<NinjaSlashAnimationTrigger>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void TriggerRunAnim()
    {
        Vector3 XOffset = new Vector3(3, 0, 0);
        //beginMoving = true;
        if (anim != null && anim.isActiveAndEnabled) // gets rid of unassignedReferenceException error
        {
           
            if (gameObject.transform.position != ninjaSlashAbilityTrigger.nearestGameObject.transform.position - XOffset)
            {
                anim.SetBool("PlayRunAnim", true);
                transform.position = Vector3.MoveTowards(transform.position, ninjaSlashAbilityTrigger.nearestGameObject.transform.position - XOffset, speed * Time.deltaTime);
            }
            else 
            {
                anim.SetBool("PlayRunAnim", false);
            }
        }
        
    }
    }

   
