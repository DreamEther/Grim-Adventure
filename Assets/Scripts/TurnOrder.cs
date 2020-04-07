using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrder : MonoBehaviour
{
    public static List<GameObject> presentInScene;
    public static List<GameObject> enemiesInScene;
    public static Queue<GameObject> turnOrder;
    [SerializeField] public List<GameObject> playerChars;
    public void Awake()
    {
        presentInScene = new List<GameObject>();
    }

    public void Start()
    {
        IListExtensions.Shuffle<GameObject>(presentInScene);

    }

    public void Update()
    {
        if(turnOrder == null) // && turn.ENEMYTURN == true
        {
            IListExtensions.Shuffle<GameObject>(presentInScene);
            InitiateTurnOrder();
            turnOrder = new Queue<GameObject>(presentInScene);
            Debug.Log("turn order count from TurnOrder class: " + turnOrder.Count);

        }
        //if(turnOrder.Count == 0)
        //{
        //    turnOrder = new Queue<GameObject>(presentInScene);
        //    Debug.Log("Turn Order: " + turnOrder);
        //}
        //need to create an event that listens each time an enemy is added to the stack
    }
    public static Queue<GameObject> GetCurrentTurnOrder()
    {
        return turnOrder;
    }

  
    public void InitiateTurnOrder()
    {
        var nextEnemyTurn = presentInScene[0].gameObject.GetComponent<Enemy>();
        var nextPlayerTurn = presentInScene[0].gameObject.GetComponent<PlayerController>();
        if (nextEnemyTurn == null)
        {
            nextPlayerTurn.isMyTurn = true;
            Debug.Log("Fist in list last in queue ismyTurn bool = " + nextPlayerTurn.isMyTurn);
           // return nextPlayerTurn.gameObject.GetComponent<PlayerController>();
           
        }
        else if (nextPlayerTurn == null)
        {
            nextEnemyTurn.isMyTurn = true;
            Debug.Log("Fist in list last in queue ismyTurn bool = " + nextEnemyTurn.isMyTurn);
            //return nextEnemyTurn.gameObject.GetComponent<Enemy>();
        }
      //  return null;
    }
    public static void SetTurnOrder()
    {
        
    }

}
