using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMinion : ScriptableObject, IEnemyMinion
{
    public Sprite aMinionType;

    public abstract void Initialize(GameObject gameObject);

    public abstract void Ability();
    public abstract void TakeDamage(); // going to implement ITakeDamage interface

    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
}


