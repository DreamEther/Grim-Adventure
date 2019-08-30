using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMinion : ScriptableObject, IEnemyMinion
{
    public int health = 10;
    public int attackPower = 5;
    public Sprite aMinionType;

    public abstract void Initialize(GameObject gameObject);

    public abstract void Ability();
    public abstract void CounterAnim();
    public abstract void TakingDamageAnim();
    public abstract void TakeDamage(); // going to implement ITakeDamage interface
}


