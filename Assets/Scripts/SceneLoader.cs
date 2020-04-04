using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static Camera currentCamera;

    private static int _currentSceneIndex; 

    public static int CurrentSceneIndex 
    {
        get
        {
            return _currentSceneIndex;
        }
        set
        {
            _currentSceneIndex = value;
        }
    }
    public void LoadNextScene()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(_currentSceneIndex + 1);
        currentCamera = Camera.main;
    }

   

}
