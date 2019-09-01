using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PocketNinjaBehavior : MonoBehaviour
{
    [HideInInspector] public int health = 10;
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController playerChar = other.gameObject.GetComponent<PlayerController>();
        if (playerChar.gameObject)
        {
            float percentChanceToCounter = Random.Range(0f, 1f);
            Debug.Log(percentChanceToCounter);
            if (percentChanceToCounter <= 0.30f)
            {
                StartCoroutine(TriggerCounterAttack());
            }
        }
    }

    public IEnumerator TriggerCounterAttack()
    {
        pocketNinjaAnimController.SetBool("CounterAttack", true);
        yield return null;
        pocketNinjaAnimController.SetBool("CounterAttack", false);

    }
    public void TakeDamage()
    {
        
    }
}
