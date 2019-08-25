using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : ScriptableObject
{
    public string aName = "New Ability";
    public int damage;
    public AudioClip aSound;

    public abstract void Initialize(GameObject gameObject);
    public abstract void TriggerAbility();
}
