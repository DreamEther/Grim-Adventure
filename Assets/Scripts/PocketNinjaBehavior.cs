using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketNinjaBehavior : MonoBehaviour
{
    [HideInInspector] public int health;
    [HideInInspector] public int attackPower;
    EnemySpawner enemySpawns;
    private Animator pocketNinjaAnimController;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawns = FindObjectOfType<EnemySpawner>();
        pocketNinjaAnimController = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerAbility()
    {
        Debug.Log("triggering ability");
    }

    public void TriggerCounterAttack()
    {
        foreach(Image laneOneSpawnPoint in enemySpawns.spawnPoint)
        {
           // if (enemySpawns.spawnPoint.transform.position)
        }
        
        pocketNinjaAnimController.SetBool("CounterAttack", true);
    }

    public void TakeDamage()
    {
        
    }
}
