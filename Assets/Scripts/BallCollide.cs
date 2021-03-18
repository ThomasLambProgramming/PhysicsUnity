using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollide : MonoBehaviour
{
    public Spawner spawner;
    public Grenade grenade;
    public bool SpawnedOnce = false;
    public GameObject button;

    public float RiseSpeed = 10f;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Ball")
        {
            spawner.SpawnBall();
            SpawnedOnce = true;
        }
    }
    private void Update()
    {
        if (SpawnedOnce)
        {
            button.SetActive(true);
            if (button.transform.position.y < -0.15f)
            {
                Vector3 temp = button.transform.position;
                temp.y += RiseSpeed * Time.deltaTime;
                button.transform.position = temp;
            }
            
        }
    }
}