using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipController : MonoBehaviour
{
    public TentacleController tentacleScript;
    private void OnTriggerEnter2D(Collider2D other)
    {
        // grab food
        if (tentacleScript.isHoldingFood == false)
        {
            if (other.CompareTag("GoodFood") || other.CompareTag("BadFood"))
            {
                other.transform.SetParent(transform);
                other.transform.localPosition = Vector3.zero;
                tentacleScript.isHoldingFood = true;    
            }
        }      
    }
}
