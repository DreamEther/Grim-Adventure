using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Ability - Ninja Run")]

public class NinjaRun : Ability
{
    private NinjaRunAnimationTrigger ninjaRunAbilityTrigger;
    [SerializeField] float speed = 2;
    public override void Initialize(GameObject gameObject)
    {
        ninjaRunAbilityTrigger = gameObject.GetComponent<NinjaRunAnimationTrigger>();
        ninjaRunAbilityTrigger.speed = speed;
    }

    public override void TriggerAbility()
    {
        ninjaRunAbilityTrigger.TriggerRunAnim();
    }
}
