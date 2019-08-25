using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability - Ninja Slash")]
public class NinjaSlash : Ability
{
    private NinjaSlashAbilityTrigger ninjaSlashAbilityTrigger;


    public override void Initialize(GameObject gameObject)
    {
        ninjaSlashAbilityTrigger = gameObject.GetComponent<NinjaSlashAbilityTrigger>();
    }

    public override void TriggerAbility()
    {
        ninjaSlashAbilityTrigger.TriggerSlashAnim();
    }

}
