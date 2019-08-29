using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaController : MonoBehaviour
{
    private Animator ninjaAnimController;
    [SerializeField] int energyLevel = 3;

    // Start is called before the first frame update
    void Start()
    {
        ninjaAnimController = GetComponent<Animator>();
        ninjaAnimController.SetBool("PlayIdleAnim", true);
    }

    public void PlayIdleAnim()
    {
        ninjaAnimController.SetBool("PlayIdleAnim", true);
    }

    public void PlayStabAnim()
    {
        ninjaAnimController.SetBool("PlayStabAnim", true);
    }
    // Update is called once per frame
    void Update()
    {
       
    }

    public void ExpendOneEnergyOnAttack()
    {
        energyLevel--;
    }
}
