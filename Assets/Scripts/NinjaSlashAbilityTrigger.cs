using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaSlashAbilityTrigger : MonoBehaviour
{
    [HideInInspector] private int damage = 5;
    [HideInInspector] Animator ninjaAnim;
    // Start is called before the first frame update
    void Start()
    {
        ninjaAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ninjaAnim = GetComponent<Animator>();
        //TriggerSlashAnim();
    }

    public void TriggerSlashAnim()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ninjaAnim.SetBool("StartSlash", true);
        }
    }
}
