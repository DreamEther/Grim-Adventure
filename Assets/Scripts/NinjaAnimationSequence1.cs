using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability - Ninja Slash")]
public class NinjaAnimationSequence1 : Ability
{
    private NinjaAttackAnimationSequence ninjaSlashAnimationTrigger;
    
    public override void Initialize(GameObject gameObject)
    {
        ninjaSlashAnimationTrigger = gameObject.GetComponent<NinjaAttackAnimationSequence>();
      
    }

    public override void TriggerAbility()
    {
        ninjaSlashAnimationTrigger.TriggerNinjaAttackSequence();
    }

}
