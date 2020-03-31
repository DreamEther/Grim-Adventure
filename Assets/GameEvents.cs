using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{

    private static GameEvents _instance;
    // Start is called before the first frame update
    public static GameEvents Instance
    {
     get {
         if (_instance == null)
         {
             _instance = GameObject.FindObjectOfType<GameEvents>();
             
             if (_instance == null)
             {
                 GameObject container = new GameObject("Event System");
                 _instance = container.AddComponent<GameEvents>();
             }
         }
     
         return _instance;
     }
    }



    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
