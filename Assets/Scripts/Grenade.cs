using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float ExplosionForce = 100f;
    public float ExplosionRadius = 30f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Collider[] collider = Physics.OverlapSphere(transform.position, ExplosionRadius);

            foreach (Collider c in collider)
            {
                Enemy enemy = c.GetComponentInParent<Enemy>();
                if (enemy != null)
                {
                    float CollisionDistance = Vector3.Distance(transform.position, c.transform.position);
                    float forceAmount = ExplosionForce / CollisionDistance;
                    Vector3 force = Vector3.Normalize(c.transform.position - transform.position) * forceAmount;
                    enemy.ApplyExplosion(force);
                }
            }
        }
    }
}
