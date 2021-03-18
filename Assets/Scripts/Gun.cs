using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Spawner spawner = null;
    public GameObject CameraGameObject = null;
    private Camera cam = null;
    public Grenade grenade;
    //public GameObject cubeTest;
    public new Transform camera;
    public Transform feetSpawn;
    
    private Vector3 spawnPos;
    private Vector3 spawnDirection;
    
    public float spawnRate = 4;
    public float distanceFromPlayer = 1;
    
    public float forceOfBullet = 10f;
    public float range = 1000f;
    
    //this is so people cant mass click the sens and have it be all weird
    public float minSens = 100f;
    public float maxSens = 3000f;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.position, camera.forward, out hit))
            {
                if (hit.transform.tag == "Button" && hit.distance < 2f)
                {
                    grenade.Explode();
                }
                else
                {
                    MakeRagdoll(hit);
                }

                //Shoot();
        }
       
    }

    void Start()
    {
        cam = CameraGameObject.GetComponent<Camera>();
    }
    void MakeRagdoll(RaycastHit hit)
    {
        
            Enemy ragdoll = hit.transform.gameObject.GetComponentInParent<Enemy>();
            if (ragdoll != null)
            {
                ragdoll.ragdollOn = true;
                Vector3 force = camera.forward * forceOfBullet;
                hit.rigidbody.AddForceAtPosition(force,hit.point);
                spawner.hitAmount++;
            }
            if (ragdoll == null)
            {
                Rigidbody temp = hit.rigidbody;
                if (temp != null)
                {
                    if (hit.transform.tag == "Lights")
                    {
                        Vector3 direction = Vector3.Normalize(transform.position - hit.transform.position);
                        Vector3 move = direction * forceOfBullet;
                        hit.rigidbody.AddForceAtPosition(-move, hit.point);
                    }
                    else if (hit.transform.tag == "Target")
                    {
                        Vector3 direction = Vector3.Normalize(transform.position - temp.transform.position);
                        Vector3 move = direction * forceOfBullet * 3;
                        temp.AddForceAtPosition(-move, hit.point);
                        Destroy(hit.transform.gameObject, 0.5f);
                        spawner.hitAmount++;
                    }
                    else
                    {
                        Vector3 direction = Vector3.Normalize(transform.position - temp.transform.position);
                        Vector3 move = direction * forceOfBullet;
                        temp.AddForceAtPosition(-move, hit.point);
                        Destroy(hit.transform.gameObject, 0.5f);
                        spawner.hitAmount++;
                    }
                }
                if (temp == null)
                {
                    ButtonLogic button = hit.transform.gameObject.GetComponentInParent<ButtonLogic>();
                    if (button != null)
                    {
                        if (spawner.WaveOver)
                        {
                            if (button.isRunSpawn)
                            {
                                spawner.SpawnRun = true;
                                spawner.MiddleSpawn = false;
                                spawner.TargetPractice = false;
                                spawner.spawnRope = false;
                            }
                            if (button.isMiddleSpawn)
                            {
                                spawner.SpawnRun = false;
                                spawner.MiddleSpawn = true;
                                spawner.TargetPractice = false;
                                spawner.spawnRope = false;
                            }
                            if (button.isTargetSpawn)
                            {
                                spawner.SpawnRun = false;
                                spawner.MiddleSpawn = false;
                                spawner.TargetPractice = true;
                                spawner.spawnRope = false;
                            }

                            if (button.isRope)
                            {
                                spawner.SpawnRun = false;
                                spawner.MiddleSpawn = false;
                                spawner.TargetPractice = false;
                                spawner.spawnRope = true;
                            }
                        }
                        if (button.isSpawnIncrease)
                        {
                            spawner.ActualSpawnTimer -= 0.4f;
                        }

                        if (button.isSpawnDecrease)
                        {
                            spawner.ActualSpawnTimer += 0.4f;
                        }

                        

                        if (button.isMouseXUp)
                        {
                            cam.mouseSensHorizontal += 150f;
                            if (cam.mouseSensHorizontal > maxSens)
                            {
                                cam.mouseSensHorizontal = maxSens;
                            }
                        }

                        if (button.isMouseXDown)
                        {
                            cam.mouseSensHorizontal -= 150f;
                            if (cam.mouseSensHorizontal < minSens)
                            {
                                cam.mouseSensHorizontal = minSens;
                            }
                        }

                        if (button.isMouseYUp)
                        {
                            cam.mouseSensVertical+= 150f;
                            if (cam.mouseSensVertical > maxSens)
                            {
                                cam.mouseSensVertical = maxSens;
                            }
                        }

                        if (button.isMouseYDown)
                        {
                            cam.mouseSensVertical -= 150f;
                            if (cam.mouseSensVertical < minSens)
                            {
                                cam.mouseSensVertical = minSens;
                            }
                        }

                        if (button.isExit)
                        {
                            Application.Quit();
                        }
                    }
                }
            }
        }
    }
    //this is a weird cube spawner thing i made, left for fun but not needed
    
    // void Shoot()
    // {
    //     RaycastHit hit;
    //     Vector3 temp = camera.position;
    //     temp.y -= 2.5f;
    //     if (Physics.Raycast(temp, camera.forward, out hit, range))
    //     {
    //         spawnDirection = -camera.forward;
    //         spawnPos = hit.point;
    //         BridgeCreate();
    //        
    //     }
    // }
    //
    // public void BridgeCreate()
    // {
    //     while (Vector3.Distance(spawnPos, transform.position) > distanceFromPlayer)
    //     {
    //         GameObject temp = Instantiate(cubeTest, spawnPos, new Quaternion());
    //         Destroy(temp, 2.0f);
    //         spawnPos += spawnDirection * spawnRate;
    //     }
    //
    //     Vector3 spawnLocation = new Vector3(feetSpawn.position.x, feetSpawn.position.y - 0.3f, feetSpawn.position.z);
    //     GameObject temp1 = Instantiate(cubeTest, spawnLocation , new Quaternion());
    //     Destroy(temp1, 2.0f);
    //     
    // }
}
