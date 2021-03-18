using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBallCollide : MonoBehaviour
{
    public Spawner spawner;
    public Grenade grenade;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Ball")
        {
            Debug.Log("REEEE");
            spawner.SpawnBall();
            
        }
    }
    
}
