using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseUI : MonoBehaviour
{
	public string _belongsTo = "nameOfPlayerChar";
	[SerializeField] public Transform itemsParent;
	public InventorySlot[] inventorySlots;	
		
}
