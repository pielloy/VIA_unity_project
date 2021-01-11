using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonVision : MonoBehaviour
{
    private bool isAttaking;

    void Awake()
    {
        enabled = false;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player")) { 
            Debug.Log("Player enter");
            Animator anim = gameObject.GetComponentInParent(typeof(Animator)) as Animator;

            enabled = true;
            anim.SetBool("isAttacking?", true);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player")) { 
            Debug.Log("Player exit");
            Animator anim = gameObject.GetComponentInParent(typeof(Animator)) as Animator;

            enabled = false;
            anim.SetBool("isAttacking?", false); 
        }
    }

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").transform != null) {
            Vector3 dir = GameObject.FindGameObjectWithTag("Player").transform.position - transform.parent.transform.position;
            Quaternion rotation = Quaternion.LookRotation(dir);
            Quaternion rot = Quaternion.Slerp(transform.parent.transform.rotation, rotation, Time.deltaTime * 4);

            print("Player : " + GameObject.FindGameObjectWithTag("Player").transform.position);
            print("Name : " + GameObject.FindGameObjectWithTag("Player").name);
            transform.parent.transform.rotation = rot;

            //transform.parent.transform.rotation = Quaternion.RotateTowards(transform.parent.transform.rotation, GameObject.FindGameObjectWithTag("Player").transform.rotation, 3 * Time.deltaTime);
            //.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
        }
    }
}
