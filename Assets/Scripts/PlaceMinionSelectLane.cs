using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaceMinionSelectLane : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    PlaceMinionButtonClicked placeMinionTrigger;
    private Image innerBoxTransparency;
    // Start is called before the first frame update
    void Start()
    {
        placeMinionTrigger = FindObjectOfType<PlaceMinionButtonClicked>();
        innerBoxTransparency = GetComponent<Image>();
    }

    void Update()
    {
        OnRightMouseClick();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (placeMinionTrigger.placeMinionButtonClicked == true)
        {
            innerBoxTransparency.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (placeMinionTrigger.placeMinionButtonClicked == true)
        {
            innerBoxTransparency.color = new Color(255, 255, 255, 0);
        }
    }

    private void OnRightMouseClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            placeMinionTrigger.placeMinionButtonClicked= false;
            UIController.combatLog.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        if (placeMinionTrigger.placeMinionButtonClicked == true)
        {
            // GetCurrentlySelectedChar(); // create this function in state controller so that it references the correct playerchar depending on whose turn it is. 
        }
    }
}
