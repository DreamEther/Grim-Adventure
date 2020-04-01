using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack Sequence - #1- slash, stab, stab")]
public class NinjaAttackSequence1 : AttackSequence
{
    private NinjaAttackAnimationSequences ninjaAttackSequence;
    public float accuracy;
    public override void Initialize(GameObject gameObject)
    {
        ninjaAttackSequence = gameObject.GetComponent<NinjaAttackAnimationSequences>();
        //ninjaAttackSequence.accuracy = accuracy;      
    }

    public override void TriggerAbility()
    {
       NinjaAttackAnimationSequences.Attack attack = ninjaAttackSequence.TriggerAttackSequence1;
       ninjaAttackSequence.TriggerNinjaAttackSequence(attack);
    }

}
