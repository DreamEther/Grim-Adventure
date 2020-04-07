using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMinion : ScriptableObject
{
    public string aName;
    public bool isDefaultMinion = false;
    public Sprite aMinionType;
    public GameObject minionPrefab;
    public abstract void Initialize(GameObject gameObject);
}


