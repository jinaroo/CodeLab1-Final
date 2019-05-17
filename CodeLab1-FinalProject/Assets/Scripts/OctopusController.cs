using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // eat good food and continue
        if (other.CompareTag("GoodFood"))
        {
            UI_Manager.instance.Score++;
            Destroy(gameObject);
        }
        
        // eat bad food and lose
        if (other.CompareTag("BadFood"))
        {            
            // lock player controls
            // have lose message pop up
        }
    }
}
