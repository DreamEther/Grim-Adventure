using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimFSM : StateMachineBehaviour
{

    public GameObject enemy;
    public GameObject opponent;
    public Animator _animator;
    public float accuracy = 4.0f;
    public int currentLane;
    public GameObject currentNPC;
    protected Queue<GameObject> turnOrder;

    public void Start()
    {
        turnOrder = new Queue<GameObject>();
        enemy = new GameObject();
    }
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // if(enemyTurn is true, then execute...since we'll know for certain that we are getting back a component that has an Enemy script)
        //  opponent = enemy.GetComponent<Enemy>().GetPlayer(); //opponent in this case is the player character\
        turnOrder = TurnOrder.GetCurrentTurnOrder();
        //  if(we are in enemyTurn state and not in PlayerTurn or MinionTurn state, then we check the list to see if the first indexed gameObject is of Type enemy. If it is not, then we return and do nothing. If it is, then we get the component of that game Object, which we know)
        //InitiateTurnOrder();
        enemy = TurnOrder.turnOrder.Dequeue();
        currentLane = enemy.GetComponent<Enemy>().GetCurrentLane();
        Debug.Log("currentLane " + currentLane);
        _animator = enemy.GetComponent<Animator>();    
    }

    //public void InitiateTurnOrder()
    //{
    //    var nextEnemyTurn = TurnOrder.presentInScene[0].gameObject.GetComponent<Enemy>();
    //    var nextPlayerTurn = TurnOrder.presentInScene[0].gameObject.GetComponent<PlayerController>();
    //    if (nextEnemyTurn == null)
    //    {
    //        nextPlayerTurn.isMyTurn = true;
    //        Debug.Log(nextPlayerTurn.isMyTurn);
    //    }
    //    else if (nextPlayerTurn == null)
    //    {
    //        nextEnemyTurn.isMyTurn = true;
    //        Debug.Log(nextEnemyTurn.isMyTurn);

    //    }
    //}


    public interface ChangeTurn
    {

    }

    //in dragonAI

    //public delegate void EnemyTurn;
    //public event EnemyTurn OnEnemyTurn;
}