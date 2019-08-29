using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability - Ninja Slash")]
public class NinjaSlash : Ability
{
    private NinjaSlashAnimationTrigger ninjaSlashAnimationTrigger;
    
    public override void Initialize(GameObject gameObject)
    {
        ninjaSlashAnimationTrigger = gameObject.GetComponent<NinjaSlashAnimationTrigger>();
      
    }

    public override void TriggerAbility()
    {
        ninjaSlashAnimationTrigger.TriggerSlashAnim();
    }

}
