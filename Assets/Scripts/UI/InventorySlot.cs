using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public bool hasClicked = false;
    public Image icon;
    public Text text;
    public string isOfType;
    public string aName;
    public AttackSequence attackSequence;
    public BaseMinion minion;
    public GameObject playerChar;
    public GameObject rushButton;
    // Use this for initialization

    void Start()
    {
        Debug.Log("Started");
    }
    public void AddAttackSequence(AttackSequence inventoryItem)
    {
        attackSequence = inventoryItem;
        attackSequence.Initialize(playerChar);
        aName = attackSequence.aName;
        text.text = aName;
        isOfType = attackSequence.isOfType;
        icon.sprite = attackSequence.icon.sprite;
        rushButton.GetComponent<Button>().onClick.AddListener(() => TriggerAbility());
        //button.onClick.AddListener(TriggerAbility);
        icon.enabled = true;
        
    }

  
    public void TriggerAbility()
    {
        hasClicked = true;
        Debug.Log("has clicked ");
    }
    public void Update()
    {
       if(hasClicked)
        {
            attackSequence.TriggerAbility();

        }

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
