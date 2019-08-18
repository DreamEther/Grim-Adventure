using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatController : MonoBehaviour
{
    [SerializeField] GameObject lane1P;
    [SerializeField] GameObject lane1E;
    [SerializeField] GameObject ninjaPrefab;
    [SerializeField] GameObject dragonPrefab;
    PlayerController playerController;
    GameObject ninja;
    float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        lane1P = GameObject.FindGameObjectWithTag("Lane1P");
        lane1E = GameObject.FindGameObjectWithTag("Lane1E");

        SpawnEnemy();
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayerInLaneOne(ninja);
    }

    private void SpawnPlayer()
    {

        ninja = Instantiate(ninjaPrefab, lane1P.transform.position, Quaternion.identity);
        MovePlayerInLaneOne(ninja);
    }

    private void MovePlayerInLaneOne(GameObject playerInLaneOne)
    {
        playerInLaneOne.GetComponent<Rigidbody2D>().MovePosition(lane1E.transform.position * speed * Time.deltaTime);
    }

    private void SpawnEnemy()
    {
        Instantiate(dragonPrefab, lane1E.transform.position, Quaternion.LookRotation(dragonPrefab.transform.forward));
    }
}
