using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_MoveRigideBody : MonoBehaviour
{
    public float m_walk_speed = 6.0f;
    public float m_run_speed = 10.0f;
    private float m_speed = 0.0f;
    public GameObject m_CameraPlayer;

    private CharacterController m_controller;
    private Vector3 m_movement;
    private GameObject m_renard;
    private Animator m_animator;

    void Start()
    {
        m_controller = this.GetComponent<CharacterController>();
        m_renard = transform.Find("Renard").gameObject;
        m_animator = transform.Find("Renard").GetComponent<Animator>();
    }

    void Update()
    {
        if (m_controller.isGrounded) {
            m_movement = new Vector3(0, 0, 0);

            m_movement += m_CameraPlayer.transform.right * Input.GetAxis("Horizontal");
            m_movement += m_CameraPlayer.transform.forward * Input.GetAxis("Vertical");
            m_movement.y = 0;
        }
        m_speed = (Input.GetAxis("Run") == 1) ? m_run_speed : m_walk_speed;
        if (Input.GetAxis("Dodge") != 0) {
            m_animator.SetBool("Dodge", true);
        }
    }

    void FixedUpdate()
    {
        m_movement.Normalize();                                // Prevent runing if we go in diagonal
        m_movement *= m_speed;                                  // Add the speed
        m_controller.SimpleMove(m_movement);                    // Move the player
        m_animator.SetFloat("Blend", m_movement.magnitude);     // Change anim depending of our speed
        if (m_movement.magnitude != 0) {                        // Rotate the player if we move
            Quaternion rotation = Quaternion.LookRotation(m_movement);

            m_renard.transform.rotation = rotation;
        }
    }

    public void AddCameraPoss(GameObject CameraPos)
    {
        m_CameraPlayer.GetComponent<S_SmoothCamera>().AddCameraPoss(CameraPos);
    }

    public void RemoveCameraPoss(GameObject CameraPos)
    {
        m_CameraPlayer.GetComponent<S_SmoothCamera>().RemoveCameraPoss(CameraPos);
    }
}
