using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_char : MonoBehaviour
{
    float Speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Speed * Time.deltaTime);
    }
}
