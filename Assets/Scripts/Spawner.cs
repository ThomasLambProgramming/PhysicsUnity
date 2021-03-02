using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab = null;
    public GameObject IdlePrefab = null;
    public float SpawnTimer = 1f;
    private float timer = 0;
    
    private float xMin = -20f;
    private float xMax = 20f;
    
    private float zMin = -20f;
    private float zMax = 20f;

    private bool SpawnRun = true;
    private bool MiddleSpawn = false;
    private bool Lookat = false;
    
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        GetInput();
        if (timer > SpawnTimer)
        {
            timer = 0f;
            if (SpawnRun)
                RunSpawn();
            else if (MiddleSpawn)
                SpawnMiddle();
            else if (Lookat)
                SpawnLooking();
        }
    }

    
    void RunSpawn()
    {
        Vector3 spawnPos = new Vector3(Random.Range(xMin, xMax), 0, Random.Range(zMin, zMax));
        GameObject temp = Instantiate(enemyPrefab, spawnPos, transform.rotation);
        if (spawnPos.x < 0)
            temp.transform.Rotate(new Vector3(0f, 90f, 0f));
        else if (spawnPos.x > 0)
            temp.transform.Rotate(new Vector3(0f, -90f, 0f));
        Destroy(temp, 4);
    }
    void SpawnMiddle()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-4, 4), 0, Random.Range(-4, 4));
        GameObject temp = Instantiate(IdlePrefab, spawnPos, transform.rotation);
        Destroy(temp, 4f);
    }
    void SpawnLooking()
    {
        
    }
    private void GetInput()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            SpawnRun = true;
            MiddleSpawn = false;
            Lookat = false;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            SpawnRun = false;
            MiddleSpawn = true;
            Lookat = false;
            SpawnTimer = 0f;
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnRun = false;
            MiddleSpawn = false;
            Lookat = true;
        }
    }

}
