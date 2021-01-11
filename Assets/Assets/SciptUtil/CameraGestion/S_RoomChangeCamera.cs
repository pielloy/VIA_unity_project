using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_RoomChangeCamera : MonoBehaviour
{
    public GameObject m_CameraPos;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.GetComponent<S_MoveRigideBody>().AddCameraPoss(m_CameraPos);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.GetComponent<S_MoveRigideBody>().RemoveCameraPoss(m_CameraPos);
        }
    }
}
