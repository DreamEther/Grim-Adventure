using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOrder : MonoBehaviour
{
    public static List<GameObject> presentInScene;
    public static List<GameObject> enemiesInScene;
    public static Queue<GameObject> turnOrder;
    public static bool updateQueue;
    public BattleSystem battleSystem;
    [SerializeField] public List<GameObject> playerChars;
    public void Awake()
    {
        presentInScene = new List<GameObject>();
      
    }

    public void Start()
    {
        battleSystem = gameObject.GetComponent<BattleSystem>();
        battleSystem.TurnChanged += OnDequeue;
        IListExtensions.Shuffle<GameObject>(presentInScene);

    }

    public void OnDequeue()
    {
        if (turnOrder == null) // && turn.ENEMYTURN == true
        {
            IListExtensions.Shuffle<GameObject>(presentInScene);
            InitiateTurnOrder(presentInScene.ToArray());
            turnOrder = new Queue<GameObject>(presentInScene);
            Debug.Log("turn order count from TurnOrder class: " + turnOrder.Count);

        }
        else
        {
            InitiateTurnOrder(turnOrder.ToArray());
            Debug.Log("OnDequeue method being triggered...current turn order count = " + turnOrder.Count);
        }
      
        //turnOrder = new Queue<GameObject>(presentInScene);
        //Debug.Log("updating turn order... " + turnOrder.Count);
    }
    public static Queue<GameObject> GetCurrentTurnOrder()
    {
        return turnOrder;
    }

    public void UpdateTurnOrder()
    {

    }

    public void InitiateTurnOrder(GameObject[] presentInScene)
    {
        var enemy = presentInScene[0].gameObject.GetComponent<Enemy>();
        var player = presentInScene[0].gameObject.GetComponent<PlayerController>();
        if (enemy == null)
        {
            player.isMyTurn = true;
            Debug.Log("Fist in list last in queue ismyTurn bool = " + player.isMyTurn);
           // return nextPlayerTurn.gameObject.GetComponent<PlayerController>();
           
        }
        else if (player == null)
        {
            enemy.isMyTurn = true;
            Debug.Log("Fist in list last in queue ismyTurn bool = " + enemy.isMyTurn);
            //return nextEnemyTurn.gameObject.GetComponent<Enemy>();
        }
      //  return null;
    }
    public static void SetTurnOrder()
    {
        
    }

}
