using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectLane : MonoBehaviour, IPointerEnterHandler
{
    GameObject lane;
    // Start is called before the first frame update
    void Start()
    {
        lane = GameObject.FindGameObjectWithTag("Lane");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {    
            Image image = lane.GetComponent<Image>();
            image.material.color = new Color(255, 255, 255, 0);           
    }

    public void MoveChar()
    {

    }

    
}
