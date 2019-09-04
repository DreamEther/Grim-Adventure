using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack Sequence - #1- slash, stab, stab")]
public class NinjaAttackSequence1 : AttackSequence
{
    private NinjaAttackAnimationSequence ninjaAttackSequence1;
    public float accuracy;
    public override void Initialize(GameObject gameObject)
    {
        ninjaAttackSequence1 = gameObject.GetComponent<NinjaAttackAnimationSequence>();
        ninjaAttackSequence1.accuracy = accuracy;
    }

    public override void TriggerAbility()
    {
       ninjaAttackSequence1.TriggerNinjaAttackSequence();
    }

}
