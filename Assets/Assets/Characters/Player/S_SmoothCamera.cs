using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_SmoothCamera : MonoBehaviour
{
    public GameObject m_FoxPlayer;
    public ArrayList m_CamerPos = new ArrayList();
    float m_maxLength = 0f;

    public void AddCameraPoss(GameObject CameraPos)
    {
        m_CamerPos.Add(CameraPos);
    }

    public void RemoveCameraPoss(GameObject CameraPos)
    {
        m_CamerPos.Remove(CameraPos);
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
        GameObject pos = m_CamerPos[m_CamerPos.Count - 1] as GameObject;

        this.transform.position = Vector3.Lerp(this.transform.position, pos.transform.position, 0.04f);
        this.transform.rotation = Quaternion.Lerp(this.transform.rotation, pos.transform.rotation, 0.05f);
        m_maxLength = 300;
    }

    void FixedUpdate()
    {
        if (m_CamerPos.Count == 0)
            MoveCameraBeindFox();
        else
            MoveCameraToPos();
    }
}
