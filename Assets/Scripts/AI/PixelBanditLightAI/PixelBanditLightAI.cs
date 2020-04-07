using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelBanditLightAI : MonoBehaviour
{
    [HideInInspector] public int health = 10;
    [HideInInspector] public int attackPower;
    private Animator pixelBanditLightAnimController;
    // Start is called before the first frame update
    void Start()
    {
        pixelBanditLightAnimController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TriggerAbility()
    {
        Debug.Log("triggering ability");
    }

    public void TakeDamage()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "ninjaSlash" || other.gameObject.tag == "ninjaStab")
        {
            StartCoroutine(TriggerHurt());
            float percentChanceToCounter = Random.Range(0f, 1f);
            Debug.Log(percentChanceToCounter);
            if (percentChanceToCounter <= 0.15f)
            {
                StartCoroutine(TriggerCounterAttack());
            }

        }

    }

    public IEnumerator TriggerHurt()
    {
        pixelBanditLightAnimController.SetBool("Hurt", true);
        yield return null;
        pixelBanditLightAnimController.SetBool("Hurt", false);

    }

    public IEnumerator TriggerCounterAttack()
    {
        pixelBanditLightAnimController.SetBool("Attack", true);
        yield return null;
        pixelBanditLightAnimController.SetBool("Attack", false);

    }
}
