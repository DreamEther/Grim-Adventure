using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathAnim : MonoBehaviour
{
    DraygonController dragon;
    private Animator fireBreath;

    // Start is called before the first frame update
    void Start()
    {
        dragon = FindObjectOfType<DraygonController>();
        fireBreath = GetComponent<Animator>();
        //fireBreath.SetBool("PlayFireAnim", true);
    }

    // Update is called once per frame
    void Update()
    {
        PlayFireBreathAnim();
    }

    public void PlayFireBreathAnim()
    {
        if (dragon.playFireBreathAnim == true)
        {
            fireBreath.SetBool("PlayFireAnim", true);
        }
    }
  
}
