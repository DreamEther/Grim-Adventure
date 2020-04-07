using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGrid : MonoBehaviour
{
    public delegate void OnClick();
    public event OnClick Clicked;
    public SelectLane[] _playerLanesList;
    private NinjaAI _ninja;
    [SerializeField] public Transform itemsParent;
   [SerializeField] public Vector3 currentlySelectedLane;
    private void Awake()
    {
        _ninja = gameObject.GetComponentInParent<NinjaAI>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentlySelectedLane = new Vector3();
        _playerLanesList = itemsParent.GetComponentsInChildren<SelectLane>();
        foreach (SelectLane lane in _playerLanesList)
        {
            Debug.Log("List of lanes and their boolean values: " + lane.isSelected);
        }
    }

    public void MovePlayerChar()
    {
        if(Clicked != null)
        {
            Clicked.Invoke();
        }
    }

    public Vector3 GetLaneOnHover()
    {
        Vector3 lanePosition = new Vector3();
        foreach (SelectLane lane in _playerLanesList)
        {
            if(lane.isSelected)
            {
                lanePosition = lane.GetComponent<Image>().transform.position;
                Debug.Log("Lane Position: " + lanePosition);
                break;
            }
           
        }
        return lanePosition;
    }

    public void SetCurrentOnHoverPosition(Vector3 imageTransform)
    {
        Vector3 removeZAxis = new Vector3(0, 0, -90);
        currentlySelectedLane = imageTransform;
        currentlySelectedLane = currentlySelectedLane + removeZAxis;
        
        Debug.Log("currently hovering on this lane: " + currentlySelectedLane);
    }

    public Vector3 GetCurrentOnHoverPosition()
    {
        return currentlySelectedLane;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
