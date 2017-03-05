using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterPool : MonoBehaviour {

    public GameObject fasterPrefab;                                 
    public int fasterPoolSize = 5;                       
    float spawnRate;                                   
    public float fasterMin = -1f;                                  
    public float fasterMax = 3.5f;                               

    private GameObject[] fasters;                                  
    private int currentFaster = 0;                                  

    private Vector2 itemMuPoolPosition = new Vector2(-15, -25);     
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;


    void Start()
    {

        timeSinceLastSpawned = 0f;

        fasters = new GameObject[fasterPoolSize];

        for (int i = 0; i < fasterPoolSize; i++)
        {

            fasters[i] = (GameObject)Instantiate(fasterPrefab, itemMuPoolPosition, Quaternion.identity);
        }
    }



    void Update()
    {

        spawnRate = Random.Range(10f, 50f);
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;

            float spawnYPosition = Random.Range(fasterMin, fasterMax);

            fasters[currentFaster].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentFaster++;

            if (currentFaster >= fasterPoolSize)
            {
                currentFaster = 0;
            }
        }
    }


}
