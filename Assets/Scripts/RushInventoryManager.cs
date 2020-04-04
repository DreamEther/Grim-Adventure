using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushInventoryManager : MonoBehaviour
{
    public delegate void ItemAdded();
    public event ItemAdded OnItemAdded;
    private NinjaAI ninja;
    private DragoonAI dragoon;
    private void Start()
    {
        ninja = gameObject.GetComponent<NinjaAI>();
        dragoon = gameObject.GetComponent<DragoonAI>();
    }
    public void AddAttackSequence(AttackSequence attackSequence)
    {
        switch(attackSequence.isOfType)
        {
            case "ninja":
                {
                    ninja.myAttackSequences.Add(attackSequence);
                    break;
                }
            case "dragoon":
                {
                    dragoon.myAttackSequences.Add(attackSequence);
                    break;
                }
        }
    }

    public void AddMinion(BaseMinion minionToAdd)
    {
    
    }


}
