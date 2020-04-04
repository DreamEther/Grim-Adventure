using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragoonRushUI : BaseUI
{
	

	private DragoonAI dragoon;
	public void Awake()
	{
		DontDestroyOnLoad(this);
	}
	public void Start()
	{
		dragoon = gameObject.GetComponent<DragoonAI>();
		inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();

		dragoon.OnSequenceAdded += UpdateUI;


	}


	private void Update()
	{

	}
	public void UpdateUI()
	{
		// Loop through all the slots
		for (int i = 0; i < inventorySlots.Length; i++)
		{
			if (i < dragoon.myAttackSequences.Count)  // If there is an item to add
			{
				inventorySlots[i].AddAttackSequence(dragoon.myAttackSequences[i]);   // Add it
			}
			else
			{
				break;
			}
		}
	}
}
