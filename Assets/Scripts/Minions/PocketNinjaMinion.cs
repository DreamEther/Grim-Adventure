using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Minion - Pocket Ninja")]
public class PocketNinjaMinion : BaseMinion
{

    public int health = 20;
    public int attackPower = 3;
    PocketNinjaBehavior pocketNinjaBehavior;

    public override void Initialize(GameObject gameObject)
    {
        pocketNinjaBehavior = gameObject.GetComponent<PocketNinjaBehavior>();
        pocketNinjaBehavior.health = health;
        pocketNinjaBehavior.attackPower = attackPower;

    }

    public override void Ability()
    {
        throw new System.NotImplementedException();
    }

    public override void TakeDamage()
    {
        throw new System.NotImplementedException();
    }
}
