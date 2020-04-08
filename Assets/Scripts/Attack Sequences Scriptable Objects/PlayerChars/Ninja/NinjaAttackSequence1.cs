using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Attack Sequence - #1- slash, stab, stab")]
public class NinjaAttackSequence1 : AttackSequence
{
    private NinjaAI ninja;
    public float accuracy;
    public override void Initialize(GameObject gameObject)
    {
        ninja = gameObject.GetComponent<NinjaAI>();
        //ninjaAttackSequence.accuracy = accuracy;      
    }

    public override void TriggerAbility(Action onAttackComplete)
    {
       PlayerController.Attack attack = ninja.AttackSequence1;
       ninja.TriggerNinjaAttackSequence(attack);
        if(ninja.energyLevel == 0)
        {
            onAttackComplete();
        }
        
    }

}
