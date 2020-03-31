using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathAnim : MonoBehaviour
{
    DraygonController playfireBreathAnim;
    private Animator fireBreath;

    // Start is called before the first frame update
    void Start()
    {
        playfireBreathAnim = FindObjectOfType<DraygonController>();
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
        if (playfireBreathAnim.playFireBreathAnim == true)
        {
            fireBreath.SetBool("PlayFireAnim", true);
        }
    }
  
}
