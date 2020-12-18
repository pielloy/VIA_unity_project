using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float speed = 1;
    float rotSpeed = 80;
    float gravity = 8;
    float rot = 0f;
    Vector3 moveDir = Vector3.zero;
    Quaternion rotation;
    CharacterController controller;
    Animator animator;
    Rigidbody rigid;
    GameObject Renard;
    private void Start() 
    {
        controller = GetComponent<CharacterController>();
        animator = transform.Find("Renard").GetComponent<Animator>();
        Renard = transform.Find("Renard").gameObject;
    }
    private void Update()
    {
        if (moveDir.x == 0 && moveDir.z == 0) {
            animator.SetInteger("Cond", 0);
        }
        else {
            animator.SetInteger("Cond", 1);
            rotation.SetLookRotation(new Vector3(moveDir.x, 0, moveDir.z));
            Renard.transform.rotation = rotation;
        }
        if(controller.isGrounded)
        {
            Direction(KeyCode.UpArrow, 1, 0);
            Direction(KeyCode.DownArrow, -1, 0);
            Direction(KeyCode.RightArrow, 0, 1);
            Direction(KeyCode.LeftArrow, 0, -1);
        }
        moveDir.y -= gravity * Time.deltaTime;
        controller.Move(moveDir * Time.deltaTime);
    }

    void Direction(KeyCode dir, int vectorx, int vectory)
    {
        Vector3 tmp;
        if (Input.GetKeyDown(dir))
            {
                tmp = new Vector3(vectory, 0, vectorx);
                tmp *= speed;
                moveDir += transform.TransformDirection(tmp);
            }
        if (Input.GetKeyUp(dir))
            {
                tmp = new Vector3(vectory, 0, vectorx);
                tmp *= speed;
                moveDir -= transform.TransformDirection(tmp);
            }
    }
}