using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AutoDestroyParticle : MonoBehaviour
{
    private ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        ps = gameObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("A");
        if (ps) {
            Debug.Log("B");
            if (!ps.IsAlive()) {
                Debug.Log("C");
                Destroy(gameObject);
            }
        }
    }
}
