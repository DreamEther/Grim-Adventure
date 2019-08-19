using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 minPlayerPos;
    public Vector3 maxPlayerPos;
    [SerializeField] float speed = 2f;


    public enum PlayerStates { InCombatMyTurn, InCombatTheirTurn }

    PlayerStates myTurn = PlayerStates.InCombatMyTurn;

    private Animator runAnim, idleAnim, slashAnim, stabAnim;
    

    // Start is called before the first frame update
    void Start()
    {
        runAnim = GetComponent<Animator>();
        slashAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
        //PlayerMovement();
        //runAnim.Play("NinjaSwordRunning");
    }

    public void PlayerMovement() // this function will be called on 'Attack' button click!
    {
      //  var deltaX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
       // var newXPos = transform.position.x + deltaX;
      //  transform.position = new Vector3(Mathf.Clamp(transform.position.x + deltaX, minPlayerPos.x, maxPlayerPos.x), 0, 0);
      
     
    }

    public void PlayRunAnim()
    {
        runAnim.SetBool("BeginLaneCharge", true);
    }

    public void PlaySlashAnim()
    {
        slashAnim.Play("NinjaSwordStriking");
    }
}
