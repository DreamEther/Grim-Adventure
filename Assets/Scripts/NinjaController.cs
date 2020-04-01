using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private Animator ninjaAnim;
    [SerializeField] public List<GameObject> minionsAcquired;

    MinionLists minionLists;
    // Start is called before the first frame update
    void Start()
    {
       ninjaAnim = gameObject.GetComponent<Animator>();
       minionLists = FindObjectOfType<MinionLists>();
       minionsAcquired = new List<GameObject>();
       if(minionLists != null)
       {
            minionsAcquired = minionLists.ninjaMinions;
            Debug.Log("Minions Acquired Count: " + minionsAcquired.Count);
       }
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnTriggerEnter2D(Collider2D other)
     {       
        if (other.gameObject.tag == "enemy")
        {
            StartCoroutine(TriggerHurt());          
        }

    }

     public IEnumerator TriggerHurt()
    {
        ninjaAnim.SetBool("Hurt", true);
        yield return null;
        ninjaAnim.SetBool("Hurt", false);
    }
}
