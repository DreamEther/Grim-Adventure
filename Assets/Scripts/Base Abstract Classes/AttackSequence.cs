using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public abstract class AttackSequence : ScriptableObject
{
    public bool isDefaultSequence = false;
    public string isOfType = "typeOfSequence";
    public string aName = "New Sequence";
    public int damage;
    public AudioClip aSound;
    public Image icon;
    public Button button;

    public abstract void Initialize(GameObject gameObject);
    public abstract void TriggerAbility(Action onAttackComplete);

}
