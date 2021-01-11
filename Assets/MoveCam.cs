using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
      float speed = 4;
    float rotSpeed = 80;
    float gravity = 8;
    float rot = 0f;
    Vector3 moveDir = Vector3.zero;
    CharacterController controller;
    Animator animator;
    private void Start() 
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                moveDir = new Vector3(1, 0, 0);
                moveDir *= speed;
            }
            if (Input.GetKeyUp(KeyCode.Z))
            {
                moveDir = new Vector3(1, 0, 0);
            }
        }
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime); 
    }
}
