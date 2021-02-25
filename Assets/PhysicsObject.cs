using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField] Material m_awakeMaterial = null;
    [SerializeField] Material m_sleepingMaterial = null;

    private Rigidbody m_rigidBody = null;
    bool wasSleeping = false;

    void Start()
    {
        m_rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_rigidBody.IsSleeping() && !wasSleeping && m_sleepingMaterial != null)
        {
            wasSleeping = true;
            GetComponent<MeshRenderer>().material = m_sleepingMaterial;
        }
        if (!m_rigidBody.IsSleeping() && wasSleeping && m_awakeMaterial != null)
        {
            wasSleeping = false;
            GetComponent<MeshRenderer>().material = m_awakeMaterial;
        }
    }
}
