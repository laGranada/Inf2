using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierPool : MonoBehaviour {

    public GameObject multiplierPrefab;                              
    public int multiplierPoolSize = 5;                             
    float spawnRate;                                   
    public float multiplierMin = -1f;                                   
    public float multiplierMax = 3.5f;                              

    private GameObject[] multipliers;                                 
    private int currentMultiplier = 0;                                  

    private Vector2 itemMuPoolPosition = new Vector2(-15, -25);   
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;


    void Start()
    {
        timeSinceLastSpawned = 0f;

        multipliers = new GameObject[multiplierPoolSize];

        for (int i = 0; i < multiplierPoolSize; i++)
        {
            multipliers[i] = (GameObject)Instantiate(multiplierPrefab, itemMuPoolPosition, Quaternion.identity);
        }
    }


    void Update()
    {

        spawnRate = Random.Range(10f, 50f);
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            float spawnYPosition = Random.Range(multiplierMin, multiplierMax);

            multipliers[currentMultiplier].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentMultiplier++;

            if (currentMultiplier >= multiplierPoolSize)
            {
                currentMultiplier = 0;
            }
        }
    }
}
