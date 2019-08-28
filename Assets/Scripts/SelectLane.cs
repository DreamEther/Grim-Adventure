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
}
