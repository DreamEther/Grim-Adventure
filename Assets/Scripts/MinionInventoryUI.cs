using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionInventoryUI : BaseUI
{
    public void UpdateUI()
    {
        return;
    }


    // Start is called before the first frame update
    void Start()
    {
        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void UpdateUI()
    //{
    //    // Loop through all the slots
    //    for (int i = 0; i < inventorySlots.Length; i++)
    //    {
    //        if (i < minions.Count)  // If there is an item to add
    //        {
    //            inventorySlots[i].AddMinion(minions[i]);   // Add it
    //        }
    //        else
    //        {
    //            break;
    //            // Otherwise clear the slot
    //            //inventorySlots[i].ClearSlot();
    //        }
    //    }
    //}

  
}
