using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Rigidbody rigid;
    public float x;
    public float z;
    public float vitesse = 2;
    Animator anim;
    Vector3 direction;
    void Start()
    {
        rigid = GetComponent<Rigidbody>(); 
        anim = gameObject.GetComponentInParent(typeof(Animator)) as Animator;  
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        print("c rapid a cet vitaiss : " + rigid.velocity.magnitude);
        anim.SetFloat("Blend", rigid.velocity.magnitude);
        direction = new Vector3(x * vitesse, 0.0f, z * vitesse);
        rigid.AddForce(direction);
    }
}
