using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonAI : MonoBehaviour
{
    private Animator anim;
    private DragonAI thisGameObject;
 

   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (_currentLane == 1)
        //{
        //    anim.SetBool("PlayAttackSequence1", true);
        //}
    }

    public IEnumerator AttackSequence1(DragonAI enemyTurn)
    {
        thisGameObject = enemyTurn;
        anim = thisGameObject.GetComponent<Animator>();
        anim.SetBool("PlayAttackSequence1", true);
        yield return null;
        anim.SetBool("PlayAttackSequence1", false);
    }

   
}
