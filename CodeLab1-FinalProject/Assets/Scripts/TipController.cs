﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipController : MonoBehaviour
{
    public TentacleController tentacleScript;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // grab food when it is not already held (has no parent)
        if (tentacleScript.isHoldingFood == false && other.transform.parent == null)
        {
            if (other.CompareTag("GoodFood") || other.CompareTag("BadFood"))
            {
                other.transform.SetParent(transform);
                other.transform.localPosition = Vector3.zero;
                other.GetComponent<FoodController>().moveSpeed = 0f; // stop food from moving after it is grabbed
                tentacleScript.isHoldingFood = true;    
            }
        }      
    }
}
