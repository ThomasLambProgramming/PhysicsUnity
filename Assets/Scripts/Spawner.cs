using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab = null;
    public GameObject IdlePrefab = null;
    public GameObject TargetPrefab = null;
    public GameObject RopeObject = null;
    public float SpawnTimer = 1f;

    public float reactionTime = 10;
    //this is so the unity value doesnt change
    public float ActualSpawnTimer = 0f;
    private float timer = 0;
    
    private float xMin = -20f;
    private float xMax = 20f;
    
    private float zMin = -10f;
    private float zMax = 20f;

    private float yMin = 2f;
    private float yMax = 7f;
    public bool spawnRope = false;
    public bool SpawnRun = true;
    public bool MiddleSpawn = false;
    public bool TargetPractice = false;
    public float waveTime = 10f;
    private float waveTimer = 0f;
    public bool Startwave = false;
    public bool PlayerLeftSpawner = true;
    public bool WaveOver = true;
    public float recentAccuracy = 0f;
    public float clicks = 0.0f;
    public float EnemysSpawned = 0f;
    
    public float hitAmount = 0f;
    
    public GameObject ResultGameObject = null;
    public TextMeshProUGUI winText = null;
    
    void Start()
    {
        ActualSpawnTimer = SpawnTimer;
    }
    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (Startwave)
        {
            waveTimer += Time.deltaTime;
        }
        if (Input.GetButtonDown("Fire1") && Startwave)
        {
            clicks++;
        }
        if (timer > ActualSpawnTimer)
        {
            timer = 0f;
            if (Startwave)
            {
                if (waveTimer > waveTime)
                {
                    
                    waveTimer = 0f;
                    Startwave = false;
                    WaveOver = true;
                    if (winText != null)
                    {
                        ResultGameObject.SetActive(true);
                        if (clicks == 0 || hitAmount == 0)
                        {
                            winText.text = "Your accuracy was 0 you hit nothing\n"
                                           + "The amount of Enemies was " + (int)EnemysSpawned + "\n " +
                                           "Please press enter to remove text";
                        }
                        else
                        {
                            winText.text = "Your accuracy was " + (int) (hitAmount / clicks * 100) + "%\n"
                                           + "The amount of Enemies was " + (int) EnemysSpawned + "\n " +
                                           "Please press enter to remove text";
                        }
                    }
                }
                else
                {
                    if (SpawnRun)
                        RunSpawn();
                    else if (MiddleSpawn)
                        SpawnMiddle();
                    else if (TargetPractice)
                        SpawnTarget();
                    else if (spawnRope)
                        SpawnRope();
                    EnemysSpawned++;
                }
            }
        }
        //-33 -55 -30 0 
        if (Input.GetKeyDown(KeyCode.Return) && ResultGameObject.activeInHierarchy)
        {
            ResultGameObject.SetActive(false);
            winText.text = "";
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
        Destroy(temp, reactionTime);
    }
    void SpawnMiddle()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-4, 4), 0, Random.Range(-4, 4));
        GameObject temp = Instantiate(IdlePrefab, spawnPos, transform.rotation);
        Destroy(temp, reactionTime);
    }
    void SpawnTarget()
    {
        Vector3 spawnPos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), Random.Range(zMin, zMax));
        GameObject temp = Instantiate(TargetPrefab, spawnPos, transform.rotation);
        Destroy(temp, reactionTime);
    }

    void SpawnRope()
    {
        Vector3 spawnPos = new Vector3(Random.Range(xMin, xMax), Random.Range( yMin + 5f, yMax), Random.Range(zMin, zMax));
        GameObject temp = Instantiate(RopeObject, spawnPos, RopeObject.transform.rotation);
        Destroy(temp, reactionTime);
    }
}
