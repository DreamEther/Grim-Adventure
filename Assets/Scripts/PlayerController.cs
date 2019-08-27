using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    PlayerParty playerParty;

    float accuracy = 5f;
    public Vector3 minPlayerPos;
    public Vector3 maxPlayerPos;
    [SerializeField] float speed = 2f;
    public static bool beginMoving = false;
    Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        playerParty = FindObjectOfType<PlayerParty>();
        anim = gameObject.GetComponent<Animator>();
        anim.GetBool("BeginLaneCharge");
    }

    // Update is called once per frame
    void Update()
    {

        
        //PlayerMovement();
        //runAnim.Play("NinjaSwordRunning");
    }


    private void DistanceFromEnemy()
    {
        var distance =  CharacterSpawner.lane1E.transform.position - this.transform.position;
        if (distance.magnitude < accuracy)
        {
            //anim.SetBool("StartSlash", true);
        }
    }

    private void MovePlayerInLaneOne(GameObject playerInLaneOne)
    {
        var laneOnePlayer = playerInLaneOne.GetComponent<Transform>();
        laneOnePlayer.transform.position = Vector3.MoveTowards(laneOnePlayer.transform.position, CharacterSpawner.lane1E.transform.position, speed * Time.deltaTime);
    }


    public void PlayRunAnim()
    {           
                beginMoving = true;
                if (anim != null && anim.isActiveAndEnabled) // gets rid of unassignedReferenceException error
                {
                    anim.SetBool("BeginLaneCharge", true);
                    MovePlayerInLaneOne(this.gameObject);
                }                   
    }

    public void PlaySlashAnim()
    {
        anim.Play("NinjaSwordStriking");
    }

   
}
