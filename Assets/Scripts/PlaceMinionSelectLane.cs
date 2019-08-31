using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlaceMinionSelectLane : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    PlaceMinionButtonClicked placeMinionTrigger;
    private Image innerBoxTransparency;
    Animator flashGreen;
    // Start is called before the first frame update
    void Start()
    {
         flashGreen = GetComponent<Animator>();
         placeMinionTrigger = FindObjectOfType<PlaceMinionButtonClicked>();
         innerBoxTransparency = this.gameObject.GetComponent<Image>();
    }

    void Update()
    {
        OnRightMouseClick();
    }

     public void OnPointerEnter(PointerEventData eventData)
     {
         if (placeMinionTrigger.placeMinionButtonClicked == true)
         {
            flashGreen.SetBool("FlashGreen", true);
            innerBoxTransparency.color = new Color(0.1121395f, 0.6792453f, 0.1340164f, 0.6588235f);  // darker green with 50% transparency
         }
     } 

    public void OnPointerExit(PointerEventData eventData)
    {
        if (placeMinionTrigger.placeMinionButtonClicked == true)
        {
            flashGreen.SetBool("FlashGreen", false);
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
