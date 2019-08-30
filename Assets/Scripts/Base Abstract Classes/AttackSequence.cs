using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackSequence : ScriptableObject
{
    public string aName = "New Sequence";
    public int damage;
    public AudioClip aSound;

    public abstract void Initialize(GameObject gameObject);
    public abstract void TriggerAbility();
}
