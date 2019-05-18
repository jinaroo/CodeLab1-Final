using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshScroller : MonoBehaviour
{
    public float scrollSpeed = 5f;
    private MeshRenderer meshRend;
    private float xOffset;
    
    // Start is called before the first frame update
    void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        xOffset += scrollSpeed * Time.deltaTime;
        meshRend.material.mainTextureOffset = new Vector2(xOffset,0);
    }
}
