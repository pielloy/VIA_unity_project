using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_CreateFootPrint : MonoBehaviour
{
    public GameObject footprint;
    private GameObject leftFoot;
    private GameObject rightFoot;

    void Start()
    {
        leftFoot = transform.Find("armature/body/body.001/body.002/Chest/Foot_Top_L/Foot_Middle_L/Foot_End_L/Foot_End_L_end").gameObject;
        rightFoot = transform.Find("armature/body/body.001/body.002/Chest/Foot_Top_R/Foot_Middle_R/Foot_End_R/Foot_End_R_end").gameObject;
    }

    void FootPrintRight()
    {
        Vector3 footPos = rightFoot.transform.position;
        Quaternion footRotation = Quaternion.Euler(90, rightFoot.transform.rotation.eulerAngles.y, 0);

        print(rightFoot.transform.rotation.eulerAngles.z);

        Instantiate(footprint, footPos, footRotation);
    }

    void FootPrintLeft()
    {
        Vector3 footPos = leftFoot.transform.position;
        Quaternion footRotation = Quaternion.Euler(90, leftFoot.transform.rotation.eulerAngles.y + 180, 0);

        print(leftFoot.transform.rotation.eulerAngles.z);

        Instantiate(footprint, footPos, footRotation);
    }
}
