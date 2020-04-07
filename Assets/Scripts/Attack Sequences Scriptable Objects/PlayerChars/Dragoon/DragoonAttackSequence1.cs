using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Attack Sequence - #1 Dragoon")]

public class DragoonAttackSequence1 : AttackSequence
{
    private DragoonAI dragoonAttackSequence;
    public override void Initialize(GameObject gameObject)
    {
        dragoonAttackSequence = gameObject.GetComponent<DragoonAI>();
    }

    public void ListenForButtonPress(Button button)
    {
        throw new System.NotImplementedException();
    }

    public override void TriggerAbility()
    {
        PlayerController.Attack attack = dragoonAttackSequence.AttackSequence1;
        dragoonAttackSequence.TriggerDragoonAttackSequence(attack);
    }
}
