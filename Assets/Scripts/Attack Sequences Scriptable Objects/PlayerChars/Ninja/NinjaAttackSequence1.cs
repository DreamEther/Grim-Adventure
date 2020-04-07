using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Attack Sequence - #1- slash, stab, stab")]
public class NinjaAttackSequence1 : AttackSequence
{
    private NinjaAI ninjaAttackSequence;
    public float accuracy;
    public override void Initialize(GameObject gameObject)
    {
        ninjaAttackSequence = gameObject.GetComponent<NinjaAI>();
        //ninjaAttackSequence.accuracy = accuracy;      
    }

    public override void TriggerAbility()
    {
       PlayerController.Attack attack = ninjaAttackSequence.AttackSequence1;
       ninjaAttackSequence.TriggerNinjaAttackSequence(attack);
    }

    public void ListenForButtonPress(Button button)
    {
        button.onClick.AddListener(() => TriggerAbility());
    }

    public void SetIcon(Image icon)
    {
        throw new System.NotImplementedException();
    }
}
