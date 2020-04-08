using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Attack Sequence - #1 Dragoon")]

public class DragoonAttackSequence1 : AttackSequence
{
    private DragoonAI dragoon;
    public override void Initialize(GameObject gameObject)
    {
        dragoon = gameObject.GetComponent<DragoonAI>();
    }

    public override void TriggerAbility(Action onAttackComplete)
    {
       PlayerController.Attack attack = dragoon.AttackSequence1;
       dragoon.TriggerDragoonAttackSequence(attack);
        if(dragoon.energyLevel == 0)
        {
            onAttackComplete();
        }
    }
}
