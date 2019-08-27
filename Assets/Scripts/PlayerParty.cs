using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParty : MonoBehaviour
{
    SceneLoader sceneLoader;
    [SerializeField] public List<GameObject> characters;


    public static PlayerParty instance;

    void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
        DontDestroyOnLoad(instance);
    }

    void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void AddCharacterToParty(GameObject character)
    {
        characters.Add(character);
        sceneLoader.LoadNextScene();
    }

    public void OnAttackClick()
    {

    }

}
