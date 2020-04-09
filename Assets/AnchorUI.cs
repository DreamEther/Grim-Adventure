using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnchorUI : MonoBehaviour
{
    [SerializeField] GameObject anchor;

    private void Start()
    {
        transform.position = anchor.transform.position;
    }
}
