using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PocketNinjaBehavior : MonoBehaviour
{
    private Animator pocketNinjaAnimController;
    // Start is called before the first frame update
    void Start()
    {
        pocketNinjaAnimController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerAbility()
    {
        Debug.Log("triggering ability");
    }

    public void TriggerCounterAttack()
    {
        pocketNinjaAnimController.SetBool("CounterAttack", true);
    }
}
