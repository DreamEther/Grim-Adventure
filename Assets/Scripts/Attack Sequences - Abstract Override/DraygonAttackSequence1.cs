using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack Sequence - Draygon#1")]
public abstract class DraygonAttackSequence1 : AttackSequence
{

    private DraygonAttackAnimationSequence1 draygonAttackAnimationSequence1;

    public override void Initialize(GameObject gameObject)
    {
        draygonAttackAnimationSequence1 = gameObject.GetComponent<DraygonAttackAnimationSequence1>();
    }

    public override void TriggerAbility()
    {
      //  draygonAttackAnimationSequence1.Trigger();
    }
}

