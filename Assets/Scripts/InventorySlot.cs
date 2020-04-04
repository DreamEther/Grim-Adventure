using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Text text;
    public string isOfType;
    public string aName;
    public AttackSequence attackSequence;
    public BaseMinion minion;

    // Use this for initialization

    void Start()
    {
        Debug.Log("Started");
    }
    public void AddAttackSequence(AttackSequence inventoryItem)
    {
        attackSequence = inventoryItem;
        aName = attackSequence.aName;
        text.text = aName;
        isOfType = attackSequence.isOfType;
        icon.sprite = attackSequence.icon.sprite;

        icon.enabled = true;
        
    }

    public void AddMinion(BaseMinion inventoryItem)
    {
        minion  = inventoryItem;
        minion.aName = inventoryItem.aName;
        //minion.isOfType = inventoryItem.isOfType;
    }

    //public void ClearSlot(IInventoryItem inventoryItem)
    //{
    //    item = inventoryItem;
    
    //}
}
