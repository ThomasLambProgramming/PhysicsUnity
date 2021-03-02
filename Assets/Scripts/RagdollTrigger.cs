using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Enemy ragdoll = other.gameObject.GetComponentInParent<Enemy>();
        if (ragdoll != null)
            ragdoll.ragdollOn = true;
    }
}
