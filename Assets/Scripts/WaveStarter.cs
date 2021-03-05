using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class WaveStarter : MonoBehaviour
{
    public Spawner spawner;

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            if (spawner.WaveOver && spawner.PlayerLeftSpawner)
            {
                if (spawner.SpawnRun || spawner.MiddleSpawn || spawner.TargetPractice || spawner.spawnRope)
                {
                    spawner.Startwave = true;
                    spawner.WaveOver = false;
                    spawner.clicks = 0f;
                    spawner.hitAmount = 0f;
                    spawner.EnemysSpawned = 0f;
                }
            }
            spawner.PlayerLeftSpawner = false;
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            spawner.PlayerLeftSpawner = true;
        }
    }
}
