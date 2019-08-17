using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private int i = 0; 

    [SerializeField] SpriteRenderer[] cliffside;
    // Start is called before the first frame update
    void Start()
    {

        foreach (SpriteRenderer layer in cliffside)
        {

            if (i <= cliffside.Length - 1)
            {
                float orthoSize = cliffside[i].bounds.size.x * Screen.height / Screen.width * 0.5f;

                Camera.main.orthographicSize = orthoSize;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
