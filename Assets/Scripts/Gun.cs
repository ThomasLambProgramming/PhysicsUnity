using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject cubeTest;
    public Transform camera;
    public Transform feetSpawn;
    
    private Vector3 spawnPos;
    private Vector3 spawnDirection;
    
    public float spawnRate = 4;
    public float distanceFromPlayer = 1;
    
    public float damage = 10f;
    public float range = 1000f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot();
            MakeRagdoll();
        }
    }

    void MakeRagdoll()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit))
        {
            Model ragdoll = hit.transform.gameObject.GetComponentInParent<Model>();
            if (ragdoll != null)
                ragdoll.ragdollOn = true;
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        Vector3 temp = camera.position;
        temp.y -= 2.5f;
        if (Physics.Raycast(temp, camera.forward, out hit, range))
        {
            spawnDirection = -camera.forward;
            spawnPos = hit.point;
            BridgeCreate();
           
        }
    }

    public void BridgeCreate()
    {
        while (Vector3.Distance(spawnPos, transform.position) > distanceFromPlayer)
        {
            GameObject temp = Instantiate(cubeTest, spawnPos, new Quaternion());
            Destroy(temp, 2.0f);
            spawnPos += spawnDirection * spawnRate;
        }

        Vector3 spawnLocation = new Vector3(feetSpawn.position.x, feetSpawn.position.y - 0.3f, feetSpawn.position.z);
        GameObject temp1 = Instantiate(cubeTest, spawnLocation , new Quaternion());
        Destroy(temp1, 2.0f);
        
    }
}
