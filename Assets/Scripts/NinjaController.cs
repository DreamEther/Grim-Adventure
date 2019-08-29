using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private Animator ninjaAnim;

    // Start is called before the first frame update
    void Start()
    {
        ninjaAnim = GetComponent<Animator>();
        ninjaAnim.SetBool("PlayIdleAnim", true);
    }

    public void PlayIdleAnim()
    {
        ninjaAnim.SetBool("PlayIdleAnim", true);
    }

    public void PlayStabAnim()
    {
        ninjaAnim.SetBool("PlayStabAnim", true);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}
