using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnim : MonoBehaviour
{
    private Animator hitBoxAnim;
    public List<SpriteRenderer> spriteRenderers;

    NinjaAI nearestGameObjectToNinja;
    // Start is called before the first frame update

    void Start()
    {
        nearestGameObjectToNinja = GetComponent<NinjaAI>();
        hitBoxAnim = GetComponentInChildren<Animator>();
        spriteRenderers = new List<SpriteRenderer>(GetComponentsInChildren<SpriteRenderer>());
        TurnOffRenderers();
    }

    // Update is called once per frame
    void Update()
    {
        if (nearestGameObjectToNinja == null)
        {
            StopCoroutine(InitiateHitBox());
        }
    }
public void PlayAnim()
{
    TurnOnRenderers();
    StartCoroutine(InitiateHitBox());
}

public void TurnOffRenderers()
{
       spriteRenderers[0].enabled = false;
       spriteRenderers[1].enabled = false;
}

public void TurnOnRenderers()
{
        spriteRenderers[0].enabled = true;
        spriteRenderers[1].enabled = true;
}
public IEnumerator InitiateHitBox()
{
    hitBoxAnim.SetBool("HitAnim", true);
    yield return new WaitForSecondsRealtime(0.80f);
    hitBoxAnim.SetBool("HitAnim", false); 
    TurnOffRenderers();
}

    public void SetPosition(Vector3 enemyPosition)
    {
        this.transform.position = enemyPosition;
    }
}
