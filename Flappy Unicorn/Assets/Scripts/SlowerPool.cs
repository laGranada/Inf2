using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerPool : MonoBehaviour {

    public GameObject slowerPrefab;                                 
    public int slowerPoolSize = 5;                                  
    float spawnRate;                                    
    public float slowerMin = -1f;                                   
    public float slowerMax = 3.5f;                                  

    private GameObject[] slowers;                                   
    private int currentSlower = 0;                                  

    private Vector2 itemMuPoolPosition = new Vector2(-15, -25);     
    private float spawnXPosition = 10f;

    private float timeSinceLastSpawned;


    void Start()
    {

        timeSinceLastSpawned = 0f;


        slowers = new GameObject[slowerPoolSize];

        for (int i = 0; i < slowerPoolSize; i++)
        {
            
            slowers[i] = (GameObject)Instantiate(slowerPrefab, itemMuPoolPosition, Quaternion.identity);
        }
    }



    void Update()
    {

        spawnRate = Random.Range(15f, 50f);
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0f;


            float spawnYPosition = Random.Range(slowerMin, slowerMax);

            slowers[currentSlower].transform.position = new Vector2(spawnXPosition, spawnYPosition);

            currentSlower++;

            if (currentSlower >= slowerPoolSize)
            {
                currentSlower = 0;
            }
        }
    }
}
