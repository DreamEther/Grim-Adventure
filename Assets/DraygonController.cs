using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraygonController : MonoBehaviour
{

    private Animator draygonAnimController;
   [SerializeField] public bool playFireBreathAnim = false;

    // Start is called before the first frame update
    void Start()
    {
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
