using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Attack Sequence - Draygon#1")]
public abstract class DragonAttackSequence1 : AttackSequence
{

    private DragonAI draygonAttackAnimationSequence1;

    public override void Initialize(GameObject gameObject)
    {
        draygonAttackAnimationSequence1 = gameObject.GetComponent<DragonAI>();
    }

    public override void TriggerAbility()
    {
      //  draygonAttackAnimationSequence1.Trigger();
    }
}

