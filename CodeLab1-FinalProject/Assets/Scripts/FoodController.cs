using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodController : MonoBehaviour
{
    // food arrays
    public GameObject[] goodFoods;
    public GameObject[] badFoods;
    
    // Start is called before the first frame update
    void Start()
    {
        // tagging all items in food arrays
        foreach (GameObject goodFood in goodFoods)
        {
            goodFood.tag = "GoodFood";
        }
        
        foreach (GameObject badFood in goodFoods)
        {
            badFood.tag = "BadFood";
        }
    }

    // Update is called once per frame
    void Update()
    {
        // change below so that they instantiate and move across the screen
        GameObject goodFood = Instantiate(goodFoods[Random.Range(0, goodFoods.Length)]);
        GameObject badFood = Instantiate(badFoods[Random.Range(0, badFoods.Length)]);
    }
}
