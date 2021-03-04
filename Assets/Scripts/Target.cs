using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float distance = 10f;
    private float distanceTraveled = 0f;
    private ConfigurableJoint joint = null;
    public float moveSpeed = 20f;

    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
    }
    void Update()
    {
        distanceTraveled += moveSpeed * Time.deltaTime;

        if (distanceTraveled > distance)
        {
            distanceTraveled = 0.0f;
            
        }
    }
}
