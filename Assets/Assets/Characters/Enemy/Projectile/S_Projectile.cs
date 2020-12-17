using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Projectile : MonoBehaviour
{
    public GameObject myPrefab;
    [SerializeField]
    private float movementSpeed = 1f;
    [SerializeField]
    private float delay = 5f;

    void Awake()
    {
        Destroy(gameObject, delay);
    }

    void Update()
    {
        transform.position += transform.forward * Time.deltaTime * movementSpeed;        
    }

    void OnTriggerEnter(Collider coll)
    {
        if (!coll.CompareTag("SeeVolume"))
            Destroy(gameObject);
    }

    void OnDestroy()
    {
        Instantiate(myPrefab, transform.position, Quaternion.identity);
    }
}
