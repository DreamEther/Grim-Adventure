using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionLists : MonoBehaviour
{
    public List<GameObject> ninjaMinions;
    public List<GameObject> draygonMinions;
    public List<GameObject> foxMinions;

    PlayerParty playerParty;

    // Start is called before the first frame update
    void Start()
    {
        ninjaMinions = new List<GameObject>();
        draygonMinions = new List<GameObject>();
        foxMinions = new List<GameObject>();
        playerParty = FindObjectOfType<PlayerParty>();
        FindStartingMinion();
        
    }

    private void FindStartingMinion()
    {
            switch(playerParty.playerOneStartingMinion[0].gameObject.tag)
            {
                case "PocketNinja":
                ninjaMinions = playerParty.playerOneStartingMinion;
                break;

                case "WingedBat":
                draygonMinions = playerParty.playerOneStartingMinion;
                break;
                
            }
    }

    // Update is called once per frame
    void Update()
    {
    
    }

}
