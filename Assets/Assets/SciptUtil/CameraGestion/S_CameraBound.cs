using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CameraBound : MonoBehaviour
{
    public float m_safeZone = 5;

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            S_SmoothCamera smoothCamera = coll.GetComponent<S_MoveRigideBody>().m_CameraPlayer.GetComponent<S_SmoothCamera>();
            BoxCollider boxCollider = transform.GetComponent<BoxCollider>();
            Vector3 centerWorld = boxCollider.transform.position + Vector3.Scale(boxCollider.transform.localScale, boxCollider.center);
            Vector3 sizeWorld = boxCollider.size / 2;

            sizeWorld.x -= m_safeZone;
            sizeWorld.z -= m_safeZone;
            Vector2 posX = new Vector2(centerWorld.x + sizeWorld.x, centerWorld.x - sizeWorld.x);
            Vector2 posZ = new Vector2(centerWorld.z + sizeWorld.z, centerWorld.z - sizeWorld.z);

            smoothCamera.AddCameraBeind(posX, posZ);
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            S_SmoothCamera smoothCamera = coll.GetComponent<S_MoveRigideBody>().m_CameraPlayer.GetComponent<S_SmoothCamera>();
            BoxCollider boxCollider = transform.GetComponent<BoxCollider>();
            Vector3 centerWorld = boxCollider.transform.position + Vector3.Scale(boxCollider.transform.localScale, boxCollider.center);
            Vector3 sizeWorld = boxCollider.size / 2;

            sizeWorld.x -= m_safeZone;
            sizeWorld.z -= m_safeZone;
            Vector2 posX = new Vector2(centerWorld.x + sizeWorld.x, centerWorld.x - sizeWorld.x);
            Vector2 posZ = new Vector2(centerWorld.z + sizeWorld.z, centerWorld.z - sizeWorld.z);

            smoothCamera.RemoveCameraBeind(posX, posZ);
        }
    }
}
