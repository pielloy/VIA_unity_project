using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_footPrintDestroyer : MonoBehaviour
{
    public float delay;

    void Start()
    {
        Destroy(gameObject, delay);
    }
}
