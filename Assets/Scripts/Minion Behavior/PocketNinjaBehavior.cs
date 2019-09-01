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

    [SerializeField] int tempHealth = 10;
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
        if (other.gameObject.tag == "ninjaSlash" || other.gameObject.tag == "ninjaStab")
        {
                StartCoroutine(TriggerHurt());
                float percentChanceToCounter = Random.Range(0f, 1f);
                Debug.Log(percentChanceToCounter);
                if (percentChanceToCounter <= 0.50f)
                {
                    StartCoroutine(TriggerCounterAttack());
                }
            
        }
        
    }

    public IEnumerator TriggerHurt()
    {
        pocketNinjaAnimController.SetBool("Hurt", true);
        yield return null;
        pocketNinjaAnimController.SetBool("Hurt", false);

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
