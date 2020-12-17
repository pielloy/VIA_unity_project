using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    public GameObject myPrefab;

    public void Shoot(string s)
    {
        Vector3 ball_pos = transform.Find("CanonArmature/Root/Root.002/Root.003/Root.004/Root.005/Root.005_end/ShootPosition").transform.position;
        Quaternion ball_rotation = transform.rotation;

        Instantiate(myPrefab, ball_pos, ball_rotation);
    }

    void Update()
    {

    }
}
