using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectLane : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    MoveButtonTrigger moveButtonTrigger;
    private Image innerBoxTransparency;
    // Start is called before the first frame update
    void Start()
    {
        moveButtonTrigger = FindObjectOfType<MoveButtonTrigger>();
        innerBoxTransparency = GetComponent<Image>();
    }

    void Update()
    {
        OnRightMouseClick();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (moveButtonTrigger.moveButtonClicked == true)
        {            
            innerBoxTransparency.color = new Color(255, 255, 255, 0.5f);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
           innerBoxTransparency.color = new Color(255, 255, 255, 0);       
    }

    private void OnRightMouseClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moveButtonTrigger.moveButtonClicked = false;
            UIController.combatLog.SetActive(true);
        }
    }
    
    private void OnMouseDown()
    {
        if (moveButtonTrigger.moveButtonClicked == true)
        {
           // GetCurrentlySelectedChar(); // create this function in state controller so that it references the correct playerchar depending on whose turn it is. 
        }
    }
}
