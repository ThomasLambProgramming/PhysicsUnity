﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float ExplosionForce = 100f;
    public float ExplosionRadius = 30f;
    public float deleteTime = 2f;
    // Update is called once per frame
    

    public void Explode()
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
                enemy.Kill();
            }
        }
    }
}
