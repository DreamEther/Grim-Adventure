using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SelectLane : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{ 
    public bool isSelected = false;
    // in ninjaAI loop through lane spots and check if isSelected is true. isSelected will only be true onEnter and false OnExit
    public delegate void OnMoveClick();
    public OnMoveClick MoveClicked;

    public Image image;
    MoveButtonTrigger moveButtonClicked;
    private Image innerBoxTransparency;
    public NinjaAI _ninja;
    public PlayerGrid playerGrid;
    // Start is called before the first frame update

    void Awake()
    {
        playerGrid = gameObject.GetComponentInParent<PlayerGrid>();
        _ninja = gameObject.GetComponent<NinjaAI>();
        Debug.Log("In awake: " + _ninja);
    }
    void Start()
    {
        _ninja = gameObject.GetComponent<NinjaAI>();
        Debug.Log("ninja game object : " + _ninja);
        moveButtonClicked = FindObjectOfType<MoveButtonTrigger>();
        innerBoxTransparency = GetComponent<Image>();
    }

    void Update()
    {
        OnRightMouseClick();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        if (moveButtonClicked.moveButtonClicked == true)
        {
            isSelected = true;
            innerBoxTransparency.color = new Color(255, 255, 255, 0.5f);
            playerGrid.SetCurrentOnHoverPosition(innerBoxTransparency.transform.position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
           isSelected = false;
           innerBoxTransparency.color = new Color(255, 255, 255, 0);       
    }
    private void OnRightMouseClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moveButtonClicked.moveButtonClicked  = false;
            UIController.combatLog.SetActive(true);
        }
    }
}
