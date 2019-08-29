using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability - Ninja Run")]

public class NinjaRun : Ability
{
    private NinjaRunAbilityTrigger ninjaRunAbilityTrigger;
    [SerializeField] float speed = 2;
    public override void Initialize(GameObject gameObject)
    {
        ninjaRunAbilityTrigger = gameObject.GetComponent<NinjaRunAbilityTrigger>();
        ninjaRunAbilityTrigger.speed = speed;
    }

    public override void TriggerAbility()
    {
        ninjaRunAbilityTrigger.TriggerRunAnim();
    }
}
