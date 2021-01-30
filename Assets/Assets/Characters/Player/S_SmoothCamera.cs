using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class CameraBeindData {
    public CameraBeindData(Vector2 pos_X, Vector2 pos_Z) {
        posX = pos_X;
        posZ = pos_Z;
    }

    public Vector2 posX;
    public Vector2 posZ;
};

public class S_SmoothCamera : MonoBehaviour
{
    public GameObject m_FoxPlayer;
    private ArrayList m_CameraPosRoom = new ArrayList();
    private ArrayList m_CameraBeind = new ArrayList();
    float m_maxLength = 0f;
    private GameObject m_PosCameraRoom = null;
    private CameraBeindData m_PosCameraBeind = null;
    private Vector3 m_decal;

    public void AddCameraPoss(GameObject CameraPos)
    {
        m_CameraPosRoom.Add(CameraPos);
        if (m_PosCameraBeind == null && m_PosCameraRoom == null)
            m_PosCameraRoom = CameraPos;
    }

    public void RemoveCameraPoss(GameObject CameraPos)
    {
        m_CameraPosRoom.Remove(CameraPos);
        priorityPos();
    }

    public void AddCameraBeind(Vector2 posX, Vector2 posZ)
    {
        CameraBeindData ret = new CameraBeindData(posX, posZ);
        m_CameraBeind.Add(ret);
        if (m_PosCameraBeind == null && m_PosCameraRoom == null)
        {
            m_PosCameraBeind = ret;
            m_decal = m_FoxPlayer.transform.position - m_FoxPlayer.transform.parent.transform.position;
            print(m_decal);
        }
    }

    public void RemoveCameraBeind(Vector2 posX, Vector2 posZ)
    {
        for (int i = 0; i != m_CameraBeind.Count; i++) {
            if ((m_CameraBeind[i] as CameraBeindData).posX == posX && (m_CameraBeind[i] as CameraBeindData).posZ == posZ) {
                m_CameraBeind.RemoveAt(i);
                priorityPos();
                return;
            }
        }
    }

    private void priorityPos()
    {
        if (m_CameraBeind.Count + m_CameraPosRoom.Count == 1) {
            if (m_CameraBeind.Count == 1)
            {
                m_PosCameraBeind = m_CameraBeind[0] as CameraBeindData;
                m_PosCameraRoom = null;
                m_decal = m_FoxPlayer.transform.position - m_FoxPlayer.transform.parent.transform.position;
                print(m_decal);
            }
            else
            {
                m_PosCameraRoom = m_CameraPosRoom[0] as GameObject;
                m_PosCameraBeind = null;
            }
        } else
        {
            m_PosCameraRoom = null;
            m_PosCameraBeind = null;
        }
    }

    void MoveCameraBeindFox()
    {
        float length = (this.transform.position - m_FoxPlayer.transform.position).magnitude;
        if (m_maxLength > 5) {
            length /= m_maxLength;
            m_maxLength -= m_maxLength / 30;
        } else {
            length /= 5;
        }
        this.transform.position = Vector3.Lerp(this.transform.position, m_FoxPlayer.transform.position, length);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, m_FoxPlayer.transform.rotation, 0.05f);
    }

    void MoveCameraToPos()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, m_PosCameraRoom.transform.position, 0.04f);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, m_PosCameraRoom.transform.rotation, 0.05f);
        m_maxLength = 300;
    }

    void MoveCameraBeindFoxWithBound()
    {
        float length = (this.transform.position - m_FoxPlayer.transform.position).magnitude;
        if (m_maxLength > 5)
        {
            length /= m_maxLength;
            m_maxLength -= m_maxLength / 30;
        }
        else
        {
            length /= 5;
        }
        Vector3 pos = Vector3.Lerp(this.transform.position, m_FoxPlayer.transform.position, length);
        pos -= m_decal;
        pos.x = Mathf.Clamp(pos.x, m_PosCameraBeind.posX.y, m_PosCameraBeind.posX.x);
        pos.z = Mathf.Clamp(pos.z, m_PosCameraBeind.posZ.y, m_PosCameraBeind.posZ.x);
        pos += m_decal;
        this.transform.position = pos;
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, m_FoxPlayer.transform.rotation, 0.05f);
    }

    void FixedUpdate()
    {
        if (m_PosCameraRoom != null)
            MoveCameraToPos();
        else if (m_PosCameraBeind != null)
            MoveCameraBeindFoxWithBound();
        else
            MoveCameraBeindFox();
    }
}
