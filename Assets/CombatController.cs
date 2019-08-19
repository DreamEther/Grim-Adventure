using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] GameObject lane1P;
    [SerializeField] GameObject lane1E;
    [SerializeField] GameObject ninjaPrefab;
    [SerializeField] GameObject dragonPrefab;
    private Animator ninjaAnim;
    PlayerController playerController;
    GameObject ninja;
    float speed = 5f;
    float accuracy = 2f;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        lane1P = GameObject.FindGameObjectWithTag("Lane1P");
        lane1E = GameObject.FindGameObjectWithTag("Lane1E");

        SpawnEnemy();
        SpawnPlayer();
    }

    void Update()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovePlayer();
        LaneOneDistanceFromEnemy();
    }

    private void SpawnPlayer()
    {

        ninja = Instantiate(ninjaPrefab, lane1P.transform.position, Quaternion.identity);
     
    }

    private void MovePlayer()
    {
        MovePlayerInLaneOne(ninja);
    }

    private void MovePlayerInLaneOne(GameObject playerInLaneOne)
    {
        var laneOnePlayer = playerInLaneOne.GetComponent<Transform>();
            laneOnePlayer.transform.position = Vector3.MoveTowards(laneOnePlayer.transform.position, lane1E.transform.position, speed * Time.deltaTime);
    }

    private void LaneOneDistanceFromEnemy()
    {
       var distance = lane1E.transform.position - ninja.transform.position;
        if(distance.magnitude < accuracy)
        {
           // Debug.Log("working");
            playerController.PlaySlashAnim();
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(dragonPrefab, lane1E.transform.position, Quaternion.LookRotation(dragonPrefab.transform.forward));
    }
}
