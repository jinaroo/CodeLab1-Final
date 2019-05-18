using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    // food arrays
    public GameObject[] goodFoods;
    public GameObject[] badFoods;
    
    public Vector3 leftSpawnPos;
    public Vector3 rightSpawnPos;
    
    // time between spawn
    public float spawnInterval = 1f;
    private float nextSpawnTime;

    public float badFoodChance = .3f;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextSpawnTime)
        {
            nextSpawnTime = Time.timeSinceLevelLoad + spawnInterval;
            
            GameObject newFood;
            
            // spawn new piece of food
            if (Random.value < badFoodChance)
            {
                // spawn bad food
                newFood = Instantiate(badFoods[Random.Range(0, badFoods.Length)]);
            }
            else
            {
                // spawn good food
                newFood = Instantiate(goodFoods[Random.Range(0, goodFoods.Length)]);
            }

            // random spawn from left or right
            if (Random.value < .5f)
            {
                newFood.transform.position = leftSpawnPos;
            }
            else
            {
                newFood.transform.position = rightSpawnPos;
                newFood.GetComponent<FoodController>().moveSpeed *= -1; // if it spawns from the right, have it move toward the left
            }
        }
    }
}
