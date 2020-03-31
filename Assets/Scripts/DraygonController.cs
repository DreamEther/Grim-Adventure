using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraygonController : MonoBehaviour
{
    MinionLists minionList;
    [SerializeField] List<GameObject> myMinions;
    private Animator draygonAnimController;
   [SerializeField] public bool playFireBreathAnim = false;

    // Start is called before the first frame update
    void Start()
    {
        minionList = FindObjectOfType<MinionLists>();
        myMinions = new List<GameObject>();
        myMinions = minionList.draygonMinions;
       // draygonAnimController = gameObject.GetComponentInChildren<Animator>() as Animator;
      //  draygonAnimController.SetBool("PlayFireAnim", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayFireBreathAnim()
    {
        playFireBreathAnim = true;
    }
}
