using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollide : MonoBehaviour
{
    public Spawner spawner;
    public Grenade grenade;
    private bool SpawnedOnce = false;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Ball")
        {
            if (!SpawnedOnce)
            {
                SpawnedOnce = true;
                Debug.Log("REEEE");
                spawner.SpawnBall();
            }

        }
    }

}