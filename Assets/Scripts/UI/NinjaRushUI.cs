using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NinjaRushUI : BaseUI
{
	private NinjaAI ninja;
	public void Awake()
	{
		ninja = gameObject.GetComponentInParent<NinjaAI>();
	}
	public void Start()
	{
		inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();
		ninja.OnSequenceAdded += UpdateUI;
		//this.gameObject.SetActive(false);

	}


	private void Update()
	{

	}


	public void UpdateUI()
	{
		// Loop through all the slots
		for (int i = 0; i < inventorySlots.Length; i++)
		{
			if (i < ninja.myAttackSequences.Count)  // If there is an item to add
			{
				inventorySlots[i].AddAttackSequence(ninja.myAttackSequences[i]);   // Add it
			}
			else
			{
				break;
			}
		}
	}
}
