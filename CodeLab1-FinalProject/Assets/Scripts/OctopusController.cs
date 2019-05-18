using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusController : MonoBehaviour
{
    public SpriteRenderer faceSprite;

    public Sprite normalSprite;
    public Sprite eatingSprite;
    public Sprite blehSprite;

    // how long eatingSprite is on screen
    public float eatingTime = .25f;

    // is octopus dead
    public bool bleh = false;

    private float nextTimeToResetFace;

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad > nextTimeToResetFace && faceSprite.sprite != normalSprite)
        {
            if (bleh == false)
            {
                faceSprite.sprite = normalSprite;
            }          
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // eat good food and continue
        if (other.CompareTag("GoodFood"))
        {
            UI_Manager.instance.Score++;

            faceSprite.sprite = eatingSprite;
            
            // parented to tip, and then to tentacle
            // not holding food anymore
            other.transform.parent.parent.GetComponent<TentacleController>().isHoldingFood = false;

            nextTimeToResetFace = Time.timeSinceLevelLoad + eatingTime;
            
            Destroy(other.gameObject);
        }
        
        // eat bad food and lose
        if (other.CompareTag("BadFood"))
        {            
            // lock player controls
            // have lose message pop up

            bleh = true;
        }
    }
}
